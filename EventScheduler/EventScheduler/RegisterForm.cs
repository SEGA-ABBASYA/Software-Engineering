using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace EventScheduler
{
    public partial class RegisterForm : Form
    {
        string ordb = "Data Source=orcl;User Id=ziad;Password=ziad";
        OracleConnection conn;
        int max_id, new_id;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            OracleCommand cmd = new OracleCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "GetID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            try
            {
                max_id = Convert.ToInt32(cmd.Parameters["id"].Value.ToString());
                new_id = max_id + 1;
            }
            catch
            {
                new_id = 1;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO users_table VALUES (:ID, :name, :email, 1000)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("id", new_id);
            cmd.Parameters.Add("name", name_txtbox.Text);
            cmd.Parameters.Add("email", email_txtbox.Text);

            int r = cmd.ExecuteNonQuery();

            if (r != -1)
            {
                MessageBox.Show("User registered successfully");
            }
            else
            {
                MessageBox.Show("Error in registration");
            }
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
