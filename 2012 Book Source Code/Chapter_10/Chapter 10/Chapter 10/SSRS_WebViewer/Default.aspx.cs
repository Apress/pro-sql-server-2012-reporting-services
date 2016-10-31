using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSRS_WebViewer
{
    public partial class _Default : System.Web.UI.Page
    {
        SSRS_WebService.ReportingService2010 rs = null; 
        
        protected void Page_Load(object sender, EventArgs e) 
        {
            try 
            {
                rs = new SSRS_WebService.ReportingService2010(); 
                rs.Credentials = System.Net.CredentialCache.DefaultCredentials; 

                SSRS_WebService.CatalogItem[] listItems = rs.ListChildren("/Pro_SSRS/Chapter_7", false);
                foreach (SSRS_WebService.CatalogItem thisItem in listItems) 
                {
                    if (thisItem.TypeName == "Report") 
                    {
                        reportList.Items.Add(thisItem.Name); 
                    } 
                } 
            }
            catch (Exception ex) 
            {
                Response.Write(ex.Message); 
            } 
        }


        protected void renderReport_Click(object sender, EventArgs e)
        {
            reportViewerWeb.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            reportViewerWeb.ServerReport.ReportServerUrl = new Uri(@"http://localhost/reportserver/"); 
            reportViewerWeb.ServerReport.ReportPath = "/Pro_SSRS/Chapter_7/" + reportList.SelectedItem.Value; 
            reportViewerWeb.ServerReport.Refresh();
        }
    }
}