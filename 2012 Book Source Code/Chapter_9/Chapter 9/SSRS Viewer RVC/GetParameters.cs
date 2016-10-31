using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using System.Collections;
using SSRS_Viewer_RVC.SSRSWebService;

namespace SSRS_Viewer_RVC
{
	public partial class GetParameters : Form
	{

		private string url;
		private string server;
		private string report;
		private Microsoft.Reporting.WinForms.ReportParameter[] parameters;
		ReportingService2010 rs;

		public GetParameters(string URL)
		{
			InitializeComponent();
			url = URL;
			string[] reportInfo = url.Split('?');
			server = reportInfo[0];
			report = reportInfo[1];
		}

		public Microsoft.Reporting.WinForms.ReportParameter[] Parameters
		{
			get
			{
				return parameters;
			}
		}

		private void GetParameters_Load(object sender, EventArgs e)
		{
			rs = new ReportingService2010();            
			rs.Credentials = System.Net.CredentialCache.DefaultCredentials;

			bool forRendering = true;
			string historyID = null;
			ParameterValue[] values = new ParameterValue[1];
			DataSourceCredentials[] credentials = null;
			ItemParameter[] parametersSSRS = null;            
			ValidValue[] pvs = null;

			int x = 5;
			int y = 30;

			try
			{
                values[0] = new ParameterValue();
                values[0].Label = "ServiceYear";
                values[0].Name = "ServiceYear";
                values[0].Value = "2009";

				parametersSSRS = rs.GetItemParameters(report, historyID, forRendering, values, credentials);                

				if (parametersSSRS != null)
				{
					foreach (ItemParameter rp in parametersSSRS)
					{						
                        this.SuspendLayout();
						this.parameterPanel.SuspendLayout();
						this.parameterPanel.SendToBack();
                        

						// now create a label for the combo box below
						Label lbl = new Label();
						lbl.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
						lbl.Location = new System.Drawing.Point(x, y);
						lbl.Name = rp.Name;
						lbl.Text = rp.Name;
						lbl.Size = new System.Drawing.Size(150, 20);
						this.parameterPanel.Controls.Add(lbl);
						x = x + 150;

						// now make a combo box and fill it
						ComboBox a = new ComboBox();
						a.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
						a.Location = new System.Drawing.Point(x, y);
						a.Name = rp.Name;
						a.Size = new System.Drawing.Size(200, 20);
						x = 5;
						y = y + 30;
						
                        this.parameterPanel.Controls.Add(a);
						this.parameterPanel.ResumeLayout(false);
						this.ResumeLayout(false);

						if (rp.ValidValues != null)
						{
							//Build listitems
							ArrayList aList = new ArrayList();
							pvs = rp.ValidValues;
							foreach (ValidValue pv in pvs)
							{
								aList.Add(new ComboItem(pv.Label, pv.Value));
							}
							//Bind listitmes to combobox
							a.DataSource = aList;
							a.DisplayMember = "Display";
							a.ValueMember = "Value";
						}
					}
				}
			}

			catch (SoapException ex)
			{
				MessageBox.Show(ex.Detail.InnerXml.ToString());
			}
		}

		private Microsoft.Reporting.WinForms.ReportParameter[] ViewerParameters()
		{
			int numCtrls = (this.parameterPanel.Controls.Count / 2);
			Microsoft.Reporting.WinForms.ReportParameter[] rp = new Microsoft.Reporting.WinForms.ReportParameter[numCtrls];
			int i = 0;

			foreach (Control ctrl in this.parameterPanel.Controls)
			{
				if (ctrl.GetType() == typeof(ComboBox))
				{
					ComboBox a = (ComboBox)ctrl;
					rp[i] = new Microsoft.Reporting.WinForms.ReportParameter();
					rp[i].Name = a.Name;
					if (a.SelectedValue != null && a.SelectedValue.ToString() != String.Empty)
					{
						rp[i].Values.Add(a.SelectedValue.ToString());
					}
					else
					{
						rp[i].Values.Add(null);
					}
					i++;
				}
			}

			return rp;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			parameters = ViewerParameters();
			this.DialogResult = DialogResult.OK;
			Close();
		}
	}

	public class ComboItem
	{
		public ComboItem(string disp, string myvalue)
		{
			if (disp != null)
				display = disp;
			else
				display = "";
			if (myvalue != null)
				val = myvalue;
			else
				val = "";
		}

		private string val;
		public string Value
		{
			get { return val; }
			set { val = value; }
		}

		private string display;
		public string Display
		{
			get { return display; }
			set { display = value; }
		}

		public override string ToString()
		{
			return display;
		}
	}
}