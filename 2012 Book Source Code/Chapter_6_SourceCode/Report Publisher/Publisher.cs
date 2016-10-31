using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Services.Protocols;
using SSRS_Publisher.SSRSWebService;

namespace SSRS_Publisher
{
	public partial class Publisher : Form
	{

		private ReportingService2010 rs;

		public Publisher()
		{
			InitializeComponent();
		}

		private string GetRSURL()
		{
			if (reportServer.Text.StartsWith("http://"))
				return reportServer.Text + "/reportserver/ReportService2010.asmx";
			else
				return "http://" + reportServer.Text + "/reportserver/ReportService2010.asmx";

		}

		private void getFolders_Click(object sender, EventArgs e)
		{
			ssrsFolders.Nodes.Clear();
			rs = new ReportingService2010();
			rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
			CatalogItem[] items = null;
			rs.Url = GetRSURL();

			TreeNode root = new TreeNode();
			root.Text = "Root";
			ssrsFolders.Nodes.Add(root);
			ssrsFolders.SelectedNode = ssrsFolders.TopNode;

			// Retrieve a list items from the server 
			try
			{
				items = rs.ListChildren("/", true);

				int j = 1;

				// Iterate through the list of items and find all of the folders and display them to the user
				foreach (CatalogItem ci in items)
				{
					if (ci.TypeName == "Folder")
					{
						Regex rx = new Regex("/");
						int matchCnt = rx.Matches(ci.Path).Count;
						if (matchCnt > j)
						{
							ssrsFolders.SelectedNode = ssrsFolders.SelectedNode.LastNode;
							j = matchCnt;
						}
						else if (matchCnt < j)
						{
							ssrsFolders.SelectedNode = ssrsFolders.SelectedNode.Parent;
							j = matchCnt;
						}
						AddNode(ci.Name);
					}
				}
			}

			catch (SoapException ex)
			{
				MessageBox.Show(ex.Detail.InnerXml.ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			// Make sure the user can see that the root folder is selected by default
			ssrsFolders.HideSelection = false;
		}

		private void AddNode(string name)
		{
			TreeNode newNode = new TreeNode(name);
			ssrsFolders.SelectedNode.Nodes.Add(newNode);
		}

		private void browseFile_Click(object sender, EventArgs e)
		{
			// Get the full pathname from the treeview control
			string pathName = ssrsFolders.SelectedNode.FullPath;

			if (pathName == "Root")
				pathName = "/";
			else
			{
				// Strip off the Root name from the path and correct the path separators for use with SRS
				pathName = pathName.Substring(4, pathName.Length - 4);
				pathName = pathName.Replace(@"\", "/");
			}

			byte[] definition = null;
			Warning[] warnings = null;
			string warningMsg = String.Empty;

			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "RDL files (*.rdl)|*.rdl|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					// Read the file and put it into a byte array to pass to SRS
					FileStream stream = File.OpenRead(openFileDialog.FileName);
					definition = new byte[stream.Length];
					stream.Read(definition, 0, (int)(stream.Length));
					stream.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

				// We are going to use the name of the rdl file as the name of our report
				string reportName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
				reportFile.Text = reportName;

				// Now lets use this information to publish the report
				try
				{
                    rs.CreateCatalogItem("Report", reportName, pathName, true, definition, null, out warnings);

					if (warnings != null)
					{
						foreach (Warning warning in warnings)
						{
							warningMsg += warning.Message + "\n";
						}
						MessageBox.Show("Report creation failed with the following warnings:\n" + warningMsg);
					}
					else
						MessageBox.Show(String.Format("Report: {0} created successfully with no warnings", reportName));

                   
				}
				catch (SoapException ex)
				{
					MessageBox.Show(ex.Detail.InnerXml.ToString());
				}

			}
		}
	}
}