
namespace EventScheduler
{
    partial class Form1
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
            this.create_event_btn = new System.Windows.Forms.Button();
            this.manage_event_btn = new System.Windows.Forms.Button();
            this.upcoming_events_btn = new System.Windows.Forms.Button();
            this.crystal_1 = new System.Windows.Forms.Button();
            this.register_event_btn = new System.Windows.Forms.Button();
            this.user_registiration_btn = new System.Windows.Forms.Button();
            this.crystal_2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(679, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event Scheduler And Planning System 🗓";
            // 
            // create_event_btn
            // 
            this.create_event_btn.Location = new System.Drawing.Point(99, 114);
            this.create_event_btn.Name = "create_event_btn";
            this.create_event_btn.Size = new System.Drawing.Size(94, 61);
            this.create_event_btn.TabIndex = 1;
            this.create_event_btn.Text = "Create Event and Check Overlaps";
            this.create_event_btn.UseVisualStyleBackColor = true;
            this.create_event_btn.Click += new System.EventHandler(this.create_event_btn_Click);
            // 
            // manage_event_btn
            // 
            this.manage_event_btn.Location = new System.Drawing.Point(308, 114);
            this.manage_event_btn.Name = "manage_event_btn";
            this.manage_event_btn.Size = new System.Drawing.Size(101, 61);
            this.manage_event_btn.TabIndex = 2;
            this.manage_event_btn.Text = "Manage Events and Check Overdues";
            this.manage_event_btn.UseVisualStyleBackColor = true;
            this.manage_event_btn.Click += new System.EventHandler(this.manage_event_btn_Click);
            // 
            // upcoming_events_btn
            // 
            this.upcoming_events_btn.Location = new System.Drawing.Point(540, 114);
            this.upcoming_events_btn.Name = "upcoming_events_btn";
            this.upcoming_events_btn.Size = new System.Drawing.Size(101, 61);
            this.upcoming_events_btn.TabIndex = 3;
            this.upcoming_events_btn.Text = "Upcoming Events Sorted by Priority";
            this.upcoming_events_btn.UseVisualStyleBackColor = true;
            this.upcoming_events_btn.Click += new System.EventHandler(this.upcoming_events_btn_Click);
            // 
            // crystal_1
            // 
            this.crystal_1.Location = new System.Drawing.Point(193, 404);
            this.crystal_1.Name = "crystal_1";
            this.crystal_1.Size = new System.Drawing.Size(97, 58);
            this.crystal_1.TabIndex = 4;
            this.crystal_1.Text = "Crystal Report 1";
            this.crystal_1.UseVisualStyleBackColor = true;
            this.crystal_1.Click += new System.EventHandler(this.crystal_1_Click);
            // 
            // register_event_btn
            // 
            this.register_event_btn.Location = new System.Drawing.Point(764, 114);
            this.register_event_btn.Name = "register_event_btn";
            this.register_event_btn.Size = new System.Drawing.Size(97, 61);
            this.register_event_btn.TabIndex = 5;
            this.register_event_btn.Text = "Register to Event and Pay Fees";
            this.register_event_btn.UseVisualStyleBackColor = true;
            this.register_event_btn.Click += new System.EventHandler(this.register_event_btn_Click);
            // 
            // user_registiration_btn
            // 
            this.user_registiration_btn.Location = new System.Drawing.Point(425, 404);
            this.user_registiration_btn.Name = "user_registiration_btn";
            this.user_registiration_btn.Size = new System.Drawing.Size(94, 58);
            this.user_registiration_btn.TabIndex = 6;
            this.user_registiration_btn.Text = "User Registiration";
            this.user_registiration_btn.UseVisualStyleBackColor = true;
            this.user_registiration_btn.Click += new System.EventHandler(this.user_registiration_btn_Click);
            // 
            // crystal_2
            // 
            this.crystal_2.Location = new System.Drawing.Point(664, 404);
            this.crystal_2.Name = "crystal_2";
            this.crystal_2.Size = new System.Drawing.Size(97, 58);
            this.crystal_2.TabIndex = 7;
            this.crystal_2.Text = "Crystal Report 2";
            this.crystal_2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 598);
            this.Controls.Add(this.crystal_2);
            this.Controls.Add(this.user_registiration_btn);
            this.Controls.Add(this.register_event_btn);
            this.Controls.Add(this.crystal_1);
            this.Controls.Add(this.upcoming_events_btn);
            this.Controls.Add(this.manage_event_btn);
            this.Controls.Add(this.create_event_btn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button create_event_btn;
        private System.Windows.Forms.Button manage_event_btn;
        private System.Windows.Forms.Button upcoming_events_btn;
        private System.Windows.Forms.Button crystal_1;
        private System.Windows.Forms.Button register_event_btn;
        private System.Windows.Forms.Button user_registiration_btn;
        private System.Windows.Forms.Button crystal_2;
    }
}

