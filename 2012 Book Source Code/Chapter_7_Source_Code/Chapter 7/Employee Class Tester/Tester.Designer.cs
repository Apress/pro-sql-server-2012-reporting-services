namespace Pro_SSRS
{
	partial class Tester
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
            this.xmlTest = new System.Windows.Forms.Button();
            this.EmployeeID = new System.Windows.Forms.TextBox();
            this.EmployeePayAmt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wsTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.VisitDate = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // xmlTest
            // 
            this.xmlTest.Location = new System.Drawing.Point(82, 159);
            this.xmlTest.Name = "xmlTest";
            this.xmlTest.Size = new System.Drawing.Size(75, 23);
            this.xmlTest.TabIndex = 4;
            this.xmlTest.Text = "Test XML";
            this.xmlTest.Click += new System.EventHandler(this.xmlTest_Click);
            // 
            // EmployeeID
            // 
            this.EmployeeID.Location = new System.Drawing.Point(111, 30);
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.Size = new System.Drawing.Size(100, 20);
            this.EmployeeID.TabIndex = 1;
            // 
            // EmployeePayAmt
            // 
            this.EmployeePayAmt.Location = new System.Drawing.Point(111, 108);
            this.EmployeePayAmt.Name = "EmployeePayAmt";
            this.EmployeePayAmt.ReadOnly = true;
            this.EmployeePayAmt.Size = new System.Drawing.Size(100, 20);
            this.EmployeePayAmt.TabIndex = 3;
            this.EmployeePayAmt.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Employee ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pay Amount";
            // 
            // wsTest
            // 
            this.wsTest.Location = new System.Drawing.Point(82, 201);
            this.wsTest.Name = "wsTest";
            this.wsTest.Size = new System.Drawing.Size(75, 23);
            this.wsTest.TabIndex = 5;
            this.wsTest.Text = "Test WS";
            this.wsTest.Click += new System.EventHandler(this.wsTest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date";
            // 
            // VisitDate
            // 
            this.VisitDate.Location = new System.Drawing.Point(111, 69);
            this.VisitDate.Mask = "00/00/0000";
            this.VisitDate.Name = "VisitDate";
            this.VisitDate.Size = new System.Drawing.Size(100, 20);
            this.VisitDate.TabIndex = 2;
            this.VisitDate.ValidatingType = typeof(System.DateTime);
            // 
            // Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 273);
            this.Controls.Add(this.VisitDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wsTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmployeePayAmt);
            this.Controls.Add(this.EmployeeID);
            this.Controls.Add(this.xmlTest);
            this.Name = "Tester";
            this.Text = "Employee Class Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button xmlTest;
		private System.Windows.Forms.TextBox EmployeeID;
		private System.Windows.Forms.TextBox EmployeePayAmt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button wsTest;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MaskedTextBox VisitDate;
	}
}

