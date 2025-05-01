
namespace EventScheduler
{
    partial class GenerateReportForm
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
            this.GenerateFormButton = new System.Windows.Forms.Button();
            this.minAttendeesText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.LocationCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenerateFormButton
            // 
            this.GenerateFormButton.Location = new System.Drawing.Point(738, 17);
            this.GenerateFormButton.Name = "GenerateFormButton";
            this.GenerateFormButton.Size = new System.Drawing.Size(279, 108);
            this.GenerateFormButton.TabIndex = 0;
            this.GenerateFormButton.Text = "Generate Report";
            this.GenerateFormButton.UseVisualStyleBackColor = true;
            this.GenerateFormButton.Click += new System.EventHandler(this.GenerateFormButton_Click);
            // 
            // minAttendeesText
            // 
            this.minAttendeesText.Location = new System.Drawing.Point(32, 40);
            this.minAttendeesText.Name = "minAttendeesText";
            this.minAttendeesText.Size = new System.Drawing.Size(272, 20);
            this.minAttendeesText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minimmun Number of Attendees";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Location Name";
            // 
            // ReportViewer
            // 
            this.ReportViewer.ActiveViewIndex = -1;
            this.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewer.Location = new System.Drawing.Point(21, 139);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.Size = new System.Drawing.Size(996, 631);
            this.ReportViewer.TabIndex = 5;
            // 
            // LocationCombo
            // 
            this.LocationCombo.FormattingEnabled = true;
            this.LocationCombo.Location = new System.Drawing.Point(32, 94);
            this.LocationCombo.Name = "LocationCombo";
            this.LocationCombo.Size = new System.Drawing.Size(272, 21);
            this.LocationCombo.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 65);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerateReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 782);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LocationCombo);
            this.Controls.Add(this.ReportViewer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minAttendeesText);
            this.Controls.Add(this.GenerateFormButton);
            this.Name = "GenerateReportForm";
            this.Text = "GenerateReportForm";
            this.Load += new System.EventHandler(this.GenerateReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateFormButton;
        private System.Windows.Forms.TextBox minAttendeesText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
        private System.Windows.Forms.ComboBox LocationCombo;
        private System.Windows.Forms.Button button1;
    }
}