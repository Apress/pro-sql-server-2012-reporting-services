namespace SSRS_Publisher
{
	partial class Publisher
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportServer = new System.Windows.Forms.TextBox();
            this.ssrsFolders = new System.Windows.Forms.TreeView();
            this.getFolders = new System.Windows.Forms.Button();
            this.browseFile = new System.Windows.Forms.Button();
            this.reportFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Report server";
            // 
            // reportServer
            // 
            this.reportServer.Location = new System.Drawing.Point(86, 6);
            this.reportServer.Name = "reportServer";
            this.reportServer.Size = new System.Drawing.Size(313, 20);
            this.reportServer.TabIndex = 1;
            // 
            // ssrsFolders
            // 
            this.ssrsFolders.Location = new System.Drawing.Point(12, 34);
            this.ssrsFolders.Name = "ssrsFolders";
            this.ssrsFolders.Size = new System.Drawing.Size(468, 498);
            this.ssrsFolders.TabIndex = 2;
            // 
            // getFolders
            // 
            this.getFolders.Location = new System.Drawing.Point(405, 4);
            this.getFolders.Name = "getFolders";
            this.getFolders.Size = new System.Drawing.Size(75, 23);
            this.getFolders.TabIndex = 3;
            this.getFolders.Text = "Go";
            this.getFolders.Click += new System.EventHandler(this.getFolders_Click);
            // 
            // browseFile
            // 
            this.browseFile.Location = new System.Drawing.Point(405, 541);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(75, 23);
            this.browseFile.TabIndex = 4;
            this.browseFile.Text = "Browse";
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // reportFile
            // 
            this.reportFile.Location = new System.Drawing.Point(86, 541);
            this.reportFile.Name = "reportFile";
            this.reportFile.Size = new System.Drawing.Size(313, 20);
            this.reportFile.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 544);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Report file";
            // 
            // Publisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 573);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportFile);
            this.Controls.Add(this.browseFile);
            this.Controls.Add(this.getFolders);
            this.Controls.Add(this.ssrsFolders);
            this.Controls.Add(this.reportServer);
            this.Controls.Add(this.label2);
            this.Name = "Publisher";
            this.Text = "Publisher";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox reportServer;
		private System.Windows.Forms.TreeView ssrsFolders;
		private System.Windows.Forms.Button getFolders;
		private System.Windows.Forms.Button browseFile;
		private System.Windows.Forms.TextBox reportFile;
		private System.Windows.Forms.Label label3;
	}
}

