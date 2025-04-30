using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;

namespace EventScheduler
{
    public partial class RegisterForm : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger";
        //OracleConnection conn;

        public RegisterForm()
        {
            InitializeComponent();
        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            //conn = new OracleConnection(ordb);
            //conn.open();
        }

        private void showpass_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            password_txtbox.PasswordChar = showpass_chkbox.Checked ? '\0' : '*';
        }

        private void login_lnklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            /*OracleCommand cmd = new OracleCommand();
              cmd.Connection = conn;
              cmd.CommandText = "INSERT INTO users VALUES (users_seq.NEXTVAL, :name, :password, :email, 1000)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", ); <-- this one
            cmd.Parameters.Add("name", name_txtbox.Text);
            cmd.Parameters.Add("password", password_txtbox.Text);
            cmd.Parameters.Add("email", email_txtbox.Text);

            int r = cmd.ExecuteNonQuery();

            if(r != -1)
            {
                MessageBox.Show("User registered successfully");
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Error in registration");
            }

            */
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // conn.Dispose();
        }
    }
}
