namespace EventScheduler
{
    partial class RegisterForm
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
            register_label = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            name_txtbox = new TextBox();
            email_txtbox = new TextBox();
            password_txtbox = new TextBox();
            showpass_chkbox = new CheckBox();
            register_btn = new Button();
            login_lnklabel = new LinkLabel();
            SuspendLayout();
            // 
            // register_label
            // 
            register_label.AutoSize = true;
            register_label.Font = new Font("Dubai", 20.0999985F, FontStyle.Bold, GraphicsUnit.Point);
            register_label.Location = new Point(57, 42);
            register_label.Name = "register_label";
            register_label.Size = new Size(1007, 113);
            register_label.TabIndex = 0;
            register_label.Text = "New Here? Let's Get You Started!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(115, 200);
            label1.Name = "label1";
            label1.Size = new Size(104, 41);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 270);
            label2.Name = "label2";
            label2.Size = new Size(95, 41);
            label2.TabIndex = 2;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(115, 340);
            label3.Name = "label3";
            label3.Size = new Size(150, 41);
            label3.TabIndex = 3;
            label3.Text = "Password:";
            // 
            // name_txtbox
            // 
            name_txtbox.Location = new Point(271, 197);
            name_txtbox.Name = "name_txtbox";
            name_txtbox.Size = new Size(524, 47);
            name_txtbox.TabIndex = 4;
            // 
            // email_txtbox
            // 
            email_txtbox.Location = new Point(271, 267);
            email_txtbox.Name = "email_txtbox";
            email_txtbox.Size = new Size(524, 47);
            email_txtbox.TabIndex = 5;
            // 
            // password_txtbox
            // 
            password_txtbox.Location = new Point(271, 334);
            password_txtbox.Name = "password_txtbox";
            password_txtbox.PasswordChar = '*';
            password_txtbox.Size = new Size(524, 47);
            password_txtbox.TabIndex = 6;
            // 
            // showpass_chkbox
            // 
            showpass_chkbox.AutoSize = true;
            showpass_chkbox.Location = new Point(803, 334);
            showpass_chkbox.Name = "showpass_chkbox";
            showpass_chkbox.Size = new Size(261, 45);
            showpass_chkbox.TabIndex = 7;
            showpass_chkbox.Text = "show password";
            showpass_chkbox.UseVisualStyleBackColor = true;
            showpass_chkbox.CheckedChanged += showpass_chkbox_CheckedChanged;
            // 
            // register_btn
            // 
            register_btn.Location = new Point(271, 438);
            register_btn.Name = "register_btn";
            register_btn.Size = new Size(188, 58);
            register_btn.TabIndex = 8;
            register_btn.Text = "Join Us!";
            register_btn.UseVisualStyleBackColor = true;
            register_btn.Click += register_btn_Click;
            // 
            // login_lnklabel
            // 
            login_lnklabel.AutoSize = true;
            login_lnklabel.Location = new Point(271, 539);
            login_lnklabel.Name = "login_lnklabel";
            login_lnklabel.Size = new Size(463, 41);
            login_lnklabel.TabIndex = 9;
            login_lnklabel.TabStop = true;
            login_lnklabel.Text = "Already a Member? Click to Login";
            login_lnklabel.LinkClicked += login_lnklabel_LinkClicked;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1593, 844);
            Controls.Add(login_lnklabel);
            Controls.Add(register_btn);
            Controls.Add(showpass_chkbox);
            Controls.Add(password_txtbox);
            Controls.Add(email_txtbox);
            Controls.Add(name_txtbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(register_label);
            Name = "RegisterForm";
            Text = "Register";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label register_label;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox name_txtbox;
        private TextBox email_txtbox;
        private TextBox password_txtbox;
        private CheckBox showpass_chkbox;
        private Button register_btn;
        private LinkLabel login_lnklabel;
    }
}