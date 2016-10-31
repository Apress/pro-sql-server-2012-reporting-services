using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Web.Services.Protocols;
using SSRS_Viewer_RVC.SSRSWebService;
//using System.DirectoryServices;
//using System.Security.Principal;


namespace SSRS_Viewer_RVC
{
    public partial class PickSchedule : Form
    {
        private string url; 
        private string server; 
        private string report; 
        private ReportingService2010 rs;

        public PickSchedule(string URL)
        {
            InitializeComponent();
            url = URL;
            string[] reportInfo = url.Split('?');
            server = reportInfo[0];
            report = reportInfo[1];
        }


        private void setSchedule_Click(object sender, EventArgs e)
        {
            ScheduleReport();
        }


        private void PickSchedule_Load(object sender, EventArgs e) 
        {
            rs = new SSRSWebService.ReportingService2010(); 
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials; 
            Schedule[] schedules = null;
        
            try 
            {
                //BKM: Had to add the URL. Book had blank
                schedules = rs.ListSchedules(null);
                
                if (schedules != null)
                {
                    //Build list items
                    ArrayList aList = new ArrayList();
                    // Now add the Do Not Schedule item
                    aList.Add(new ComboItem("Do not schedule", "NS"));
                    // And the Snapshot schedule
                    aList.Add(new ComboItem("Schedule with Snapshot", "SS"));
                    foreach (Schedule s in schedules)
                    {
                        aList.Add(new ComboItem(s.Description, s.ScheduleID)); 
                        Debug.WriteLine(String.Format("Desc: {0} - ID: {1}", s.Description, s.ScheduleID)); 
                    }

                    //Bind list items to combo box 
                    sharedSchedules.DataSource = aList; 
                    sharedSchedules.DisplayMember = "Display"; 
                    sharedSchedules.ValueMember = "Value"; 
                } 
            }
            
            catch (SoapException ex) 
            { 
                MessageBox.Show(ex.Detail.InnerXml.ToString()); 
            }
        }


        private void ScheduleReport()
        {

            // See whether the user wants to schedule this versus run it now
            if (sharedSchedules.SelectedValue.ToString() != "NS")
            {
                string desc = "Send report via email";
                string eventType = String.Empty;
                string matchData = String.Empty;

                // If the user selected SnapShot, then
                // set up the parameters for a snapshot
                if (sharedSchedules.SelectedValue.ToString() == "SS")
                {
                    eventType = "SnapshotUpdated";
                    matchData = null;
                }

                // otherwise the user is using a subscription 
                else
                {
                    eventType = "TimedSubscription";
                    matchData = sharedSchedules.SelectedValue.ToString();
                }

                ParameterValue[] extensionParams = new ParameterValue[8];
                extensionParams[0] = new ParameterValue(); 
                extensionParams[0].Name = "TO"; 
                extensionParams[0].Value = "someone@company.com";
                //extensionParams[0].Value = GetEmailFromAD();

                extensionParams[1] = new ParameterValue(); 
                extensionParams[1].Name = "ReplyTo"; 
                extensionParams[1].Value = "reporting@company.com";

                extensionParams[2] = new ParameterValue(); 
                extensionParams[2].Name = "IncludeReport"; 
                extensionParams[2].Value = "True";

                extensionParams[3] = new ParameterValue(); 
                extensionParams[3].Name = "RenderFormat"; 
                extensionParams[3].Value = "PDF";

                extensionParams[4] = new ParameterValue(); 
                extensionParams[4].Name = "Subject"; 
                extensionParams[4].Value = "@ReportName was executed at @ExecutionTime";

                extensionParams[5] = new ParameterValue(); 
                extensionParams[5].Name = "Comment"; 
                extensionParams[5].Value = "Here is your @ReportName report.";

                extensionParams[6] = new ParameterValue(); 
                extensionParams[6].Name = "IncludeLink"; 
                extensionParams[6].Value = "True";

                extensionParams[7] = new ParameterValue(); 
                extensionParams[7].Name = "Priority"; 
                extensionParams[7].Value = "NORMAL";
                //ParameterValue[] pvs = ReportParameters();

                // Configure the extension settings required 
                // for the CreateSubscription method 
                ExtensionSettings extSettings = new ExtensionSettings();
                extSettings.ParameterValues = extensionParams;
                extSettings.Extension = "Report Server Email";

                // Get the report parameters using the GetParameters form 
                GetParameters reportParameters = new GetParameters(url);
                reportParameters.ShowDialog();
                Microsoft.Reporting.WinForms.ReportParameter[] rps = reportParameters.Parameters;

                // Convert the Winforms.ReportParameter returned
                // from the GetParameters to ParameterValues required for
                // the CreateSubscription method
                int i = 0;
                foreach (Microsoft.Reporting.WinForms.ReportParameter rp in rps)
                {
                    if (rp.Values.Count != 0) i++;
                }

                ParameterValue[] pvs = new ParameterValue[i];
                int j = 0;
                foreach (Microsoft.Reporting.WinForms.ReportParameter rp in rps)
                {
                    if (rp.Values.Count != 0)
                    {
                        pvs[j] = new ParameterValue();
                        pvs[j].Name = rp.Name;
                        pvs[j].Value = rp.Values[0];
                        j++;
                    }
                }

                // Now set up the subscription
                try
                {
                    rs.CreateSubscription(report, extSettings, desc, eventType, matchData, pvs);
                }

                catch (SoapException ex)
                {
                    MessageBox.Show(ex.Detail.InnerXml.ToString());
                }
            }
        }

        private void sharedSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

            
        //========================================================================//
        //  Brian K. McDonald, MCDBA, MCSD
        //  
        //  Listing 10-10: Code to Query Active Directory for E-mail Addresses
        //  Since all readers will not have Active Directory, We have left this
        //  code commented out. 
        //========================================================================//
        //private string GetEmailFromAD()
        //{

        //    DirectoryEntry rootEntry;
        //    DirectoryEntry contextEntry;
        //    DirectorySearcher searcher;
        //    SearchResult result;

        //    string currentUserName;
        //    string contextPath;

        //    WindowsPrincipal wp =
        //        new WindowsPrincipal(WindowsIdentity.GetCurrent());
        //    currentUserName = wp.Identity.Name.Split('\\')[1];

        //    rootEntry = new DirectoryEntry("LDAP://RootDSE");
        //    contextPath =
        //        rootEntry.Properties["defaultNamingContext"].Value.ToString();

        //    rootEntry.Dispose();
        //    contextEntry = new DirectoryEntry("LDAP://" + contextPath);

        //    searcher = new DirectorySearcher();
        //    searcher.SearchRoot = contextEntry;
        //    searcher.Filter =
        //        String.Format("(&(objectCategory=person)(samAccountName={0}))",
        //        currentUserName);
        //    searcher.PropertiesToLoad.Add("mail");
        //    searcher.PropertiesToLoad.Add("cn");
        //    searcher.SearchScope = SearchScope.Subtree;

        //    result = searcher.FindOne();

        //    return result.Properties["mail"][0].ToString();
        //}

      

    }


}
