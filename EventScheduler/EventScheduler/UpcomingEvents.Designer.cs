
namespace EventScheduler
{
    partial class UpcomingEvents
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
            this.upcoming_datagridview = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.upcoming_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // upcoming_datagridview
            // 
            this.upcoming_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.upcoming_datagridview.Location = new System.Drawing.Point(12, 27);
            this.upcoming_datagridview.Name = "upcoming_datagridview";
            this.upcoming_datagridview.Size = new System.Drawing.Size(716, 411);
            this.upcoming_datagridview.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpcomingEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 534);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.upcoming_datagridview);
            this.Name = "UpcomingEvents";
            this.Text = "UpcomingEvents";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpcomingEvents_FormClosing);
            this.Load += new System.EventHandler(this.UpcomingEvents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upcoming_datagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView upcoming_datagridview;
        private System.Windows.Forms.Button button1;
    }
}