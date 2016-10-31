namespace SSRS_Viewer_RVC
{
	partial class ViewerRVC
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportURL = new System.Windows.Forms.TextBox();
            this.runServer = new System.Windows.Forms.Button();
            this.runLocal = new System.Windows.Forms.Button();
            this.getParameters = new System.Windows.Forms.Button();
            this.pickSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.AccessibleName = "WinReportServiceViewer";
            this.reportViewer.AllowDrop = true;
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.AutoScroll = true;
            reportDataSource1.Name = "Employees_EmployeePay";
            reportDataSource1.Value = null;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DisplayName = "SSRS_Viewer_RVC.EmployeePay.rdlc";
            this.reportViewer.LocalReport.ReportEmbeddedResource = "SSRS_Viewer_RVC.EmployeePay.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(13, 41);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(847, 513);
            this.reportViewer.TabIndex = 0;
            // 
            // reportURL
            // 
            this.reportURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportURL.Location = new System.Drawing.Point(13, 15);
            this.reportURL.Name = "reportURL";
            this.reportURL.Size = new System.Drawing.Size(503, 20);
            this.reportURL.TabIndex = 1;
            // 
            // runServer
            // 
            this.runServer.Location = new System.Drawing.Point(543, 12);
            this.runServer.Name = "runServer";
            this.runServer.Size = new System.Drawing.Size(75, 23);
            this.runServer.TabIndex = 2;
            this.runServer.Text = "Run Server";
            this.runServer.Click += new System.EventHandler(this.runServer_Click);
            // 
            // runLocal
            // 
            this.runLocal.Location = new System.Drawing.Point(624, 12);
            this.runLocal.Name = "runLocal";
            this.runLocal.Size = new System.Drawing.Size(75, 23);
            this.runLocal.TabIndex = 3;
            this.runLocal.Text = "Run Local";
            this.runLocal.Click += new System.EventHandler(this.runLocal_Click);
            // 
            // getParameters
            // 
            this.getParameters.Location = new System.Drawing.Point(705, 12);
            this.getParameters.Name = "getParameters";
            this.getParameters.Size = new System.Drawing.Size(75, 23);
            this.getParameters.TabIndex = 4;
            this.getParameters.Text = "Parameters";
            this.getParameters.Click += new System.EventHandler(this.getParameters_Click);
            // 
            // pickSchedule
            // 
            this.pickSchedule.Location = new System.Drawing.Point(786, 12);
            this.pickSchedule.Name = "pickSchedule";
            this.pickSchedule.Size = new System.Drawing.Size(77, 23);
            this.pickSchedule.TabIndex = 5;
            this.pickSchedule.Text = "Schedule";
            this.pickSchedule.UseVisualStyleBackColor = true;
            this.pickSchedule.Click += new System.EventHandler(this.pickSchedule_Click);
            // 
            // ViewerRVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 566);
            this.Controls.Add(this.pickSchedule);
            this.Controls.Add(this.getParameters);
            this.Controls.Add(this.runLocal);
            this.Controls.Add(this.runServer);
            this.Controls.Add(this.reportURL);
            this.Controls.Add(this.reportViewer);
            this.Name = "ViewerRVC";
            this.Text = "SSRS Viewer RVC";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
		private System.Windows.Forms.TextBox reportURL;
		private System.Windows.Forms.Button runServer;
		private System.Windows.Forms.Button runLocal;
		private System.Windows.Forms.Button getParameters;
        private System.Windows.Forms.Button pickSchedule;
	}
}

