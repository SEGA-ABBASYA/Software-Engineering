using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Net;
using System.Net.Mail;

/**
 * 
 * Events Registeration and Tickets Transmission
 * Functional Requirements 4, 5, 7
 * Used Procedures without using SysRefCursor
 * Used Select, Update and Insert SQL queries
 * 
 **/


namespace EventScheduler
{
    public partial class AllEvents : Form
    {
        private const string ConnectionString = "Data Source=orcl;User Id=ziad;Password=ziad";
        private OracleConnection conn;
        private double balance = 0.0;
        private int userID = -1;
        private string email;

        public AllEvents()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void AllEvents_Load(object sender, EventArgs e)
        {

            conn = new OracleConnection(ConnectionString);
            conn.Open();
            UpdateBalanceLabel();
            FillTable();

        }

        private void UpdateBalanceLabel()
        {
            label1.Text = $"BALANCE: {balance:C}";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var registerColumn = dataGridView1.Columns["Register"];
            if (registerColumn != null && e.ColumnIndex == registerColumn.Index)
            {
                ProcessRegistration(e.RowIndex);
            }
        }

        private void ProcessRegistration(int rowIndex)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            double fees = Convert.ToDouble(row.Cells["fees"].Value);
            string eventName = row.Cells["Name"].Value.ToString();
            int eventId = Convert.ToInt32(row.Cells["ID"].Value);
            if (userID < 0)
            {
                MessageBox.Show($"Please enter a valid username!");
                return;
            }
            if (IsRegistered(eventId))
            {
                MessageBox.Show($"You are already registered in {eventName}!");
                return;
            }
            if (balance < fees)
            {
                MessageBox.Show($"Insufficient funds for {eventName}\nRequired: {fees:C}\nAvailable: {balance:C}");
                return;
            }

            double newBalance = balance - fees;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Participants_table VALUES (:userID, :eventId)";
            cmd.Parameters.Add("userID", OracleDbType.Int32).Value = userID;
            cmd.Parameters.Add("eventId", OracleDbType.Int32).Value = eventId;
            cmd.ExecuteNonQuery();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE USERS_table SET balance_fees = :newBalance WHERE id = :userID";
            cmd.Parameters.Add("newBalance", OracleDbType.Decimal).Value = newBalance;
            cmd.Parameters.Add("userID", OracleDbType.Int32).Value = userID;
            cmd.ExecuteNonQuery();


            balance = newBalance;
            UpdateBalanceLabel();
            MessageBox.Show($"Successfully paid {fees:C} for {eventName}\nNew balance: {newBalance:C}\nCheck your email for the ticket");
            string recipient = email;
            string subject = "Your Event Ticket";
            string body = $@"
                            <p>Your user ID is: <strong>{userID}, We are waiting to see you 🎇</strong></p>
                        ";
            SendEmail(recipient, subject, body);
        }

        private void FillTable()
        {
            string sql = @"SELECT * 
               FROM events_table 
               WHERE status = :statusParam";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Parameters.Add("statusParam", OracleDbType.Varchar2).Value = "upcoming";

            OracleDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            reader.Close();


            if (!dataGridView1.Columns.Contains("Register"))
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
                {
                    Name = "Register",
                    HeaderText = "Register",
                    Text = "Register",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnColumn);
            }
        }

        public bool IsRegistered(int eventId)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Participants_table where user_id = :userID AND event_id = :eventId ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("userID", OracleDbType.Int32).Value = userID;
            cmd.Parameters.Add("eventID", OracleDbType.Int32).Value = eventId;
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return cnt > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currPrefix = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(currPrefix))
            {
                FillTable();
                return;
            }

            string sql = @"SELECT * 
               FROM Events_Table 
               WHERE UPPER(name) LIKE UPPER(:prefix)";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("prefix", OracleDbType.Varchar2).Value = currPrefix + "%";

            OracleDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            reader.Close();


            if (!dataGridView1.Columns.Contains("Register"))
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
                {
                    Name = "Register",
                    HeaderText = "Register",
                    Text = "Register",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(btnColumn);
            }
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GET_USER_BALANCE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_user_name", textBox2.Text.Trim());
            cmd.Parameters.Add("p_balance", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.Parameters.Add("p_user_id", OracleDbType.Int32, ParameterDirection.Output);

            try { 
                cmd.ExecuteNonQuery();
                OracleDecimal oracleBalance = (OracleDecimal)cmd.Parameters["p_balance"].Value;
                balance = oracleBalance.ToDouble();
                userID = ((OracleDecimal)cmd.Parameters["p_user_id"].Value).ToInt32();
                UpdateBalanceLabel();
                email = GetEmail();

            }
            catch(Exception)
            {
                MessageBox.Show($"Invalid Username!");
                textBox2.Clear();
            }
        }
        public void SendEmail(string email, string subject, string body)
        {
            MailAddress from = new MailAddress("iixcellz25@gmail.com", "SEGA-ABBASYA");
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("iixcellz25@gmail.com", "awqz qczf wwlt qvcu");
            client.EnableSsl = true;

            client.Send(message);
        }
        public String GetEmail()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT email FROM Users_table where id = :userID";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("userID", OracleDbType.Int32).Value = userID;
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                email = reader.GetString(0);
            }
            Console.WriteLine(email);
            return email;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllEvents_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
