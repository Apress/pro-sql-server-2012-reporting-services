namespace SSRS_Viewer_RVC
{
    partial class PickSchedule
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
            this.sharedSchedules = new System.Windows.Forms.ComboBox();
            this.setSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schedules";
            // 
            // sharedSchedules
            // 
            this.sharedSchedules.FormattingEnabled = true;
            this.sharedSchedules.Location = new System.Drawing.Point(76, 29);
            this.sharedSchedules.Name = "sharedSchedules";
            this.sharedSchedules.Size = new System.Drawing.Size(331, 21);
            this.sharedSchedules.TabIndex = 1;
            this.sharedSchedules.SelectedIndexChanged += new System.EventHandler(this.sharedSchedules_SelectedIndexChanged);
            // 
            // setSchedule
            // 
            this.setSchedule.Location = new System.Drawing.Point(176, 67);
            this.setSchedule.Name = "setSchedule";
            this.setSchedule.Size = new System.Drawing.Size(75, 23);
            this.setSchedule.TabIndex = 2;
            this.setSchedule.Text = "OK";
            this.setSchedule.UseVisualStyleBackColor = true;
            this.setSchedule.Click += new System.EventHandler(this.setSchedule_Click);
            // 
            // PickSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 112);
            this.Controls.Add(this.setSchedule);
            this.Controls.Add(this.sharedSchedules);
            this.Controls.Add(this.label1);
            this.Name = "PickSchedule";
            this.Text = "PickSchedule";
            this.Load += new System.EventHandler(this.PickSchedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sharedSchedules;
        private System.Windows.Forms.Button setSchedule;
    }
}