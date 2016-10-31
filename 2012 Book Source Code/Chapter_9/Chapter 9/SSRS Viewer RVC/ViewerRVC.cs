using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SSRS_Viewer_RVC
{
	public partial class ViewerRVC : Form
	{
		public ViewerRVC()
		{
			InitializeComponent();
		}

		private void runServer_Click(object sender, EventArgs e)
		{
			reportURL.Text = "/Pro_SSRS/Chapter_9/EmployeeServiceCost";
			reportViewer.ProcessingMode = ProcessingMode.Remote;
            reportViewer.ServerReport.ReportServerUrl = new Uri("http://localhost/reportserver/");
			reportViewer.ServerReport.ReportPath = reportURL.Text;
			reportViewer.RefreshReport();            
		}

		private void runLocal_Click(object sender, EventArgs e)
		{
			Employees empDS = new Employees();
			empDS.ReadXml(@"C:\Temp\EmployeePay.xml");
			reportViewer.ProcessingMode = ProcessingMode.Local;
			reportViewer.LocalReport.ReportEmbeddedResource = "SSRS_Viewer_RVC.EmployeePay.rdlc";
			reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Employees_EmployeePay", empDS.Tables["EmployeePay"]));
			reportViewer.RefreshReport();
		}
        

		private void getParameters_Click(object sender, EventArgs e)
		{
            reportURL.Text = "http://localhost/reportserver?/Pro_SSRS/Chapter_9/EmployeeServiceCost";
			GetParameters reportParameters = new GetParameters(reportURL.Text);
			if (reportParameters.ShowDialog() == DialogResult.OK)
			{
				reportViewer.ProcessingMode = ProcessingMode.Remote;
                reportViewer.ServerReport.ReportServerUrl = new Uri(@"http://localhost/reportserver/");
				reportViewer.ServerReport.ReportPath = "/Pro_SSRS/Chapter_9/EmployeeServiceCost";
				reportViewer.ServerReport.SetParameters(reportParameters.Parameters);
				reportViewer.ShowParameterPrompts = false;
				reportViewer.RefreshReport();
			}
		}
	}
}