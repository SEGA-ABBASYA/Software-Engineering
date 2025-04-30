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
            upcoming_label = new Label();
            upcoming_datagridview = new DataGridView();
            upcoming_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)upcoming_datagridview).BeginInit();
            SuspendLayout();
            // 
            // upcoming_label
            // 
            upcoming_label.AutoSize = true;
            upcoming_label.Font = new Font("Dubai", 20.0999985F, FontStyle.Bold, GraphicsUnit.Point);
            upcoming_label.Location = new Point(45, 52);
            upcoming_label.Name = "upcoming_label";
            upcoming_label.Size = new Size(440, 113);
            upcoming_label.TabIndex = 1;
            upcoming_label.Text = "My Events🔖";
            // 
            // upcoming_datagridview
            // 
            upcoming_datagridview.AllowUserToAddRows = false;
            upcoming_datagridview.AllowUserToDeleteRows = false;
            upcoming_datagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            upcoming_datagridview.Location = new Point(69, 168);
            upcoming_datagridview.Name = "upcoming_datagridview";
            upcoming_datagridview.ReadOnly = true;
            upcoming_datagridview.RowHeadersWidth = 102;
            upcoming_datagridview.RowTemplate.Height = 49;
            upcoming_datagridview.Size = new Size(1453, 485);
            upcoming_datagridview.TabIndex = 2;
            // 
            // upcoming_btn
            // 
            upcoming_btn.Location = new Point(1334, 717);
            upcoming_btn.Name = "upcoming_btn";
            upcoming_btn.Size = new Size(188, 58);
            upcoming_btn.TabIndex = 3;
            upcoming_btn.Text = "Back";
            upcoming_btn.UseVisualStyleBackColor = true;
            upcoming_btn.Click += upcoming_btn_Click;
            // 
            // UpcomingEvents
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1593, 844);
            Controls.Add(upcoming_btn);
            Controls.Add(upcoming_datagridview);
            Controls.Add(upcoming_label);
            Name = "UpcomingEvents";
            Text = "UpcomingEvents";
            Load += UpcomingEvents_Load;
            ((System.ComponentModel.ISupportInitialize)upcoming_datagridview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label upcoming_label;
        private DataGridView upcoming_datagridview;
        private Button upcoming_btn;
    }
}