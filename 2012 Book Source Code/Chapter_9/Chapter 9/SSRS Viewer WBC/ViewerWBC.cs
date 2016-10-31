using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSRS_Viewer_WBC
{
	public partial class ViewerWBC : Form
	{
		public ViewerWBC()
		{
			InitializeComponent();
			// Setting the initial URL for convenience in the example
			reportURL.Text = "http://localhost/reportserver/?/Pro_SSRS/Chapter_9/EmployeeServiceCost&rs:Command=Render";
		}

		private void reportRun_Click(object sender, EventArgs e)
		{
			webBrowser.Navigate(reportURL.Text);
		}
	}
}