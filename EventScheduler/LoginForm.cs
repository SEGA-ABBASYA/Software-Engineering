//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;

namespace EventScheduler
{
    public partial class LoginForm : Form
    {
        // same style connection string as RegisterForm
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger";
        //OracleConnection conn;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //conn = new OracleConnection(ordb);
            //conn.Open();
        }

        private void register_lnklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // navigate back to register
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            /*OracleCommand cmd = new OracleCommand();
              cmd.Connection = conn;
              cmd.CommandText = @"
                  SELECT COUNT(*) 
                    FROM users 
                   WHERE email = :email 
                     AND password = :password";
              cmd.CommandType = CommandType.Text;
              cmd.Parameters.Add("email", email_txtbox.Text);
              cmd.Parameters.Add("password", password_txtbox.Text);

              int count = Convert.ToInt32(cmd.ExecuteScalar());

              if (count > 0)
              {
                  MessageBox.Show("Login successful", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  // proceed to main application form
                  MainForm mainForm = new MainForm();
                  mainForm.Show();
                  this.Hide();
              }
              else
              {
                  MessageBox.Show("Login failed. Email or password is incorrect", 
                                  "Error", 
                                  MessageBoxButtons.OK, 
                                  MessageBoxIcon.Error);
              }
            */
        }
    }
}