using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace EventScheduler
{
    public partial class CreateEvent : Form
    {
        public CreateEvent()
        {
            InitializeComponent();
        }

        OracleConnection conn;
        string connectionString = "Data Source=ORCL;User Id=ziad;Password=ziad;";

        private void CreateEvent_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(connectionString);
            conn.Open();
            cmbPriority.Items.AddRange(new object[] { 1, 2, 3 });
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (!ValidInput()) return;

            string name = txtName.Text.Trim();
            string location = txtLocation.Text.Trim().ToLower();
            DateTime eventDate = dtpDate.Value.Date;
            string status = "upcoming";
            int priority = Convert.ToInt32(cmbPriority.SelectedItem);
            decimal fees = decimal.Parse(numFees.Text);

            if (CheckForOverlap(location, eventDate))
            {
                MessageBox.Show("Overlap detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string insertSql = @"INSERT INTO events_table
                                     (id, name, location, event_date, status, priority, fees)
                                     VALUES (events_seq.NEXTVAL, :name, :location, :event_date, :status, :priority, :fees)";

                using (var cmd = new OracleCommand(insertSql, conn))
                {
                    cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = name;
                    cmd.Parameters.Add("location", OracleDbType.Varchar2).Value = location;
                    cmd.Parameters.Add("event_date", OracleDbType.Date).Value = eventDate;
                    cmd.Parameters.Add("status", OracleDbType.Varchar2).Value = status;
                    cmd.Parameters.Add("priority", OracleDbType.Int32).Value = priority;
                    cmd.Parameters.Add("fees", OracleDbType.Decimal).Value = fees;

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Event added successfully!");
                    }
                }
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
        }

        private bool CheckForOverlap(string location, DateTime date)
        {
            try
            {
                string overlapSql = @"SELECT name FROM events_table
                                      WHERE LOWER(location) = :location
                                        AND event_date = :event_date";

                using (var cmd = new OracleCommand(overlapSql, conn))
                {
                    cmd.Parameters.Add("location", OracleDbType.Varchar2).Value = location;
                    cmd.Parameters.Add("event_date", OracleDbType.Date).Value = date;

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            lstOverlapps.Items.Clear();
                            while (dr.Read())
                            {
                                lstOverlapps.Items.Add(dr["name"].ToString());
                            }
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Overlap check error: {ex.Message}");
            }

            return false;
        }

        private bool ValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Name and Location are required!");
                return false;
            }

            if (!decimal.TryParse(numFees.Text, out _))
            {
                MessageBox.Show("Invalid fee format!");
                return false;
            }

            if (cmbPriority.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Priority!");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtLocation.Clear();
            numFees.Value = 0;
            dtpDate.Value = DateTime.Today;
            cmbPriority.SelectedIndex = -1;
            lstOverlapps.Items.Clear();
        }

        private void CreateEvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Dispose();
            }
        }
    }
}