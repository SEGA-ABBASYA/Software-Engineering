using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace EventScheduler
{
    public partial class AllEvents : Form
    {
        private const string ConnectionString = "Data Source=orcl;User Id=ziad;Password=ziad";
        private OracleConnection conn;
        private double balance = 0.0;
        private int userID;

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
            MessageBox.Show($"Successfully paid {fees:C} for {eventName}\nNew balance: {newBalance:C}");
           
        }

        private void FillTable()
        {
            string sql = @"SELECT * 
                           FROM events_table 
                           WHERE status = :statusParam";
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("statusParam", OracleDbType.Varchar2).Value = "upcoming";
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
            }

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
            string sql = "SELECT COUNT(1) FROM Participants_table WHERE event_id = :eventId AND user_id = :userID";
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("eventId", OracleDbType.Int32).Value = eventId;
                cmd.Parameters.Add("userID", OracleDbType.Int32).Value = userID;
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
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
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("prefix", OracleDbType.Varchar2).Value = currPrefix + "%";

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
            }

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

        private void button2_Click(object sender, EventArgs e)
        {

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GET_USER_BALANCE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_user_name", textBox2.Text.Trim());
                cmd.Parameters.Add("p_balance", OracleDbType.Decimal, ParameterDirection.Output);
                cmd.Parameters.Add("p_user_id", OracleDbType.Int32, ParameterDirection.Output);

                cmd.ExecuteNonQuery();

                OracleDecimal oracleBalance = (OracleDecimal)cmd.Parameters["p_balance"].Value;
                balance = oracleBalance.ToDouble();
                userID = ((OracleDecimal)cmd.Parameters["p_user_id"].Value).ToInt32();

                UpdateBalanceLabel();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
