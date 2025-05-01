using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace EventScheduler
{
    public partial class AllEventsForm : Form
    {
        string ordb = "kfnajda";
        OracleConnection conn;
        double balance = 80.0;
        int userID = 41;

        public bool isRegistered(int eventID) {
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = "SELECT COUNT(1) FROM Participant where event_id = :eventId AND user_id = :userID";
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("eventID",OracleDbType.Int32).Value = eventID;
            //cmd.Parameters.Add("userID",OracleDbType.Int32).Value = userID;

            //int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            //return cnt > 0;
            return true;
        }
        public AllEventsForm()
        {
            InitializeComponent();
            //conn.ConnectionString = ordb;
            //conn.Open();
            label1.Text = $"BALANCE: {balance}$";
            dataGridView1.CellContentClick += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridView1.Columns["Register"].Index && e.RowIndex >= 0)
                {

                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    
                    double fees = Convert.ToDouble(row.Cells["fees"].Value);
                    string name = row.Cells["EventName"].Value.ToString();
                    int id = Convert.ToInt32(row.Cells["ID"].Value);

                    if (isRegistered(id)) {
                        MessageBox.Show($"You are alerady registered in {name}!");
                        return;
                    }

                    if (balance >= fees)
                    {
                        double newBalance = balance - fees;
                        balance = newBalance;

                        //OracleCommand cmd = new OracleCommand();
                        //cmd.Connection = conn;
                        //cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = "INSERT INTO Participant (id1,id2) Values (:id1,:id2)";
                        //cmd.Parameters.Add("id1", OracleDbType.Int32).Value = id;
                        //cmd.Parameters.Add("id2", OracleDbType.Int32).Value = userID;

                        //cmd.ExecuteNonQuery();

                        //cmd = new OracleCommand();
                        //cmd.Connection = conn;
                        //cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = "UPDATE USER SET balance = :newBalance where id = :id";
                        //cmd.Parameters.Add("newBalance", OracleDbType.Decimal).Value = newBalance;
                        //cmd.Parameters.Add("id", OracleDbType.Int32).Value = userID;

                        //cmd.ExecuteNonQuery();

                        label1.Text = $"BALANCE: {balance}$";
                        MessageBox.Show($"Successfully paid {fees:C} for {name}\nNew balance: {newBalance:C}");
                    }
                    else
                    {
                        MessageBox.Show($"Insufficient funds for {name}\nRequired: {fees:C}\nAvailable: {balance:C}");
                    }
                }
            };
            dataGridView1.Rows.Add(1, "Tech Conference 2023", "Convention Center", "2023-11-15", 299.99, "High", "Upcoming", "Register");
            dataGridView1.Rows.Add(2, "Music Festival", "Central Park", "2023-08-20", 149.50, "Medium", "Ongoing", "Register");
            dataGridView1.Rows.Add(3, "Art Exhibition", "City Museum", "2023-09-05", 25.00, "Low", "Completed","Register");
            dataGridView1.Rows.Add(4, "Business Workshop", "Downtown Plaza", "2023-10-10", 199.99, "High", "Upcoming","Register");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.Clear();
            //string currPrefix = textBox1.Text;
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = $"Select * From Event_Table where UPPER(name) LIKE UPPER ({currPrefix}) || '%'";
            //cmd.CommandType = CommandType.Text;
            //OracleDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    int index = dataGridView1.Rows.Add();

            //    for (int i = 0; i < 7; i++)
            //        dataGridView1.Rows[index].Cells[i].Value = reader[i].ToString();

            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
