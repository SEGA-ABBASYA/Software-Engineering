
namespace EventScheduler
{
    partial class GenerateReport1Form
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
            this.GenerateReportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameText = new System.Windows.Forms.TextBox();
            this.Report1Viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.Location = new System.Drawing.Point(788, 12);
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Size = new System.Drawing.Size(299, 116);
            this.GenerateReportButton.TabIndex = 0;
            this.GenerateReportButton.Text = "Generate Report";
            this.GenerateReportButton.UseVisualStyleBackColor = true;
            this.GenerateReportButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // UserNameText
            // 
            this.UserNameText.Location = new System.Drawing.Point(38, 68);
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.Size = new System.Drawing.Size(272, 20);
            this.UserNameText.TabIndex = 2;
            // 
            // Report1Viewer
            // 
            this.Report1Viewer.ActiveViewIndex = -1;
            this.Report1Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Report1Viewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.Report1Viewer.Location = new System.Drawing.Point(12, 142);
            this.Report1Viewer.Name = "Report1Viewer";
            this.Report1Viewer.Size = new System.Drawing.Size(1075, 598);
            this.Report1Viewer.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 65);
            this.button1.TabIndex = 4;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GenerateReport1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 752);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Report1Viewer);
            this.Controls.Add(this.UserNameText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GenerateReportButton);
            this.Name = "GenerateReport1Form";
            this.Text = "GenerateReport1Form";
            this.Load += new System.EventHandler(this.GenerateReport1Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateReportButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserNameText;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Report1Viewer;
        private System.Windows.Forms.Button button1;
    }
}