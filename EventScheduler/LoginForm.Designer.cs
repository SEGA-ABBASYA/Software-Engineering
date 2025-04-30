namespace EventScheduler
{
    partial class LoginForm
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
            title_label = new Label();
            email_txtbox = new TextBox();
            password_txtbox = new TextBox();
            email_label = new Label();
            password_label = new Label();
            Login_btn = new Button();
            register_lnklabel = new LinkLabel();
            SuspendLayout();
            // 
            // title_label
            // 
            title_label.AutoSize = true;
            title_label.Font = new Font("Microsoft YaHei UI", 20.1F, FontStyle.Regular, GraphicsUnit.Point);
            title_label.Location = new Point(600, 110);
            title_label.Name = "title_label";
            title_label.Size = new Size(405, 88);
            title_label.TabIndex = 0;
            title_label.Text = "Plannrrr 📅";
            title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // email_txtbox
            // 
            email_txtbox.Location = new Point(600, 262);
            email_txtbox.Name = "email_txtbox";
            email_txtbox.Size = new Size(383, 47);
            email_txtbox.TabIndex = 1;
            // 
            // password_txtbox
            // 
            password_txtbox.Location = new Point(600, 349);
            password_txtbox.Name = "password_txtbox";
            password_txtbox.PasswordChar = '*';
            password_txtbox.Size = new Size(383, 47);
            password_txtbox.TabIndex = 2;
            // 
            // email_label
            // 
            email_label.AutoSize = true;
            email_label.Location = new Point(436, 265);
            email_label.Name = "email_label";
            email_label.Size = new Size(103, 41);
            email_label.TabIndex = 3;
            email_label.Text = "Email: ";
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.Location = new Point(436, 352);
            password_label.Name = "password_label";
            password_label.Size = new Size(158, 41);
            password_label.TabIndex = 4;
            password_label.Text = "Password: ";
            // 
            // Login_btn
            // 
            Login_btn.Location = new Point(685, 446);
            Login_btn.Name = "Login_btn";
            Login_btn.Size = new Size(188, 58);
            Login_btn.TabIndex = 5;
            Login_btn.Text = "Login";
            Login_btn.UseVisualStyleBackColor = true;
            Login_btn.Click += Login_btn_Click;
            // 
            // register_lnklabel
            // 
            register_lnklabel.AutoSize = true;
            register_lnklabel.Location = new Point(556, 537);
            register_lnklabel.Name = "register_lnklabel";
            register_lnklabel.Size = new Size(449, 41);
            register_lnklabel.TabIndex = 6;
            register_lnklabel.TabStop = true;
            register_lnklabel.Text = "Not a Member? Click To Register";
            register_lnklabel.LinkClicked += register_lnklabel_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1593, 844);
            Controls.Add(register_lnklabel);
            Controls.Add(Login_btn);
            Controls.Add(password_label);
            Controls.Add(email_label);
            Controls.Add(password_txtbox);
            Controls.Add(email_txtbox);
            Controls.Add(title_label);
            Name = "LoginForm";
            Text = "Welcome!";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title_label;
        private TextBox email_txtbox;
        private TextBox password_txtbox;
        private Label email_label;
        private Label password_label;
        private Button Login_btn;
        private LinkLabel register_lnklabel;
    }
}