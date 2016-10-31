namespace SSRS_Viewer_WBC
{
	partial class ViewerWBC
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.reportURL = new System.Windows.Forms.TextBox();
            this.reportRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(0, 50);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(792, 530);
            this.webBrowser.TabIndex = 3;
            // 
            // reportURL
            // 
            this.reportURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportURL.Location = new System.Drawing.Point(13, 13);
            this.reportURL.Name = "reportURL";
            this.reportURL.Size = new System.Drawing.Size(675, 20);
            this.reportURL.TabIndex = 1;
            // 
            // reportRun
            // 
            this.reportRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reportRun.Location = new System.Drawing.Point(705, 11);
            this.reportRun.Name = "reportRun";
            this.reportRun.Size = new System.Drawing.Size(75, 23);
            this.reportRun.TabIndex = 2;
            this.reportRun.Text = "Run";
            this.reportRun.Click += new System.EventHandler(this.reportRun_Click);
            // 
            // ViewerWBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.reportRun);
            this.Controls.Add(this.reportURL);
            this.Controls.Add(this.webBrowser);
            this.Name = "ViewerWBC";
            this.Text = "SSRS Viewer WBC";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.TextBox reportURL;
		private System.Windows.Forms.Button reportRun;
	}
}

