using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Timers;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace EventScheduler
{
    public partial class UpcomingEvents : Form
    {
        string ordb = "Data Source=orcl;User Id=ziad;Password=ziad";
        OracleConnection conn;
        public UpcomingEvents()
        {
            InitializeComponent();
        }
        private System.Timers.Timer dailyTimer;

        private void UpcomingEvents_Load(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                conn = new OracleConnection(ordb);
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = @"SELECT *
                                    FROM events_table
                                    WHERE event_date > SYSDATE
                                    ORDER BY priority desc";

                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                // Setup DataGridView
                upcoming_datagridview.Rows.Clear();
                upcoming_datagridview.Columns.Clear();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    upcoming_datagridview.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] row = new object[reader.FieldCount];
                    reader.GetValues(row);
                    upcoming_datagridview.Rows.Add(row);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events: " + ex.Message);
            }
            dailyTimer = new System.Timers.Timer(86400000);
            dailyTimer.AutoReset = true; 
            dailyTimer.Elapsed += (s, ev) =>
            {
                try
                {
                    SendTomorrowReminders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while sending reminder: {ex.Message}");
                }
            };
            dailyTimer.Start();

        }

        private void UpcomingEvents_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        public void SendReminderEmail(string email, string subject, string body)
        {
            MailAddress from = new MailAddress("iixcellz25@gmail.com");
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to)
            {
                Subject = subject, Body = body, IsBodyHtml = true
            };
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("iixcellz25@gmail.com", "awqz qczf wwlt qvcu");
            client.EnableSsl = true;

            client.Send(message);

        }
        public void SendTomorrowReminders()
        {
            OracleConnection conn = new OracleConnection(ordb);
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "get_tomorrow_event_participants";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("result_cursor", OracleDbType.RefCursor)
                          .Direction = ParameterDirection.Output;

            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string eventName = reader.GetString(0);    // e.name
                string email = reader.GetString(1);    // u.email
                string subject = $"Reminder: {eventName} is tomorrow";
                string body = $"Don’t forget your event “{eventName}” tomorrow";
                SendReminderEmail(email, subject, body);
            }
        }
    }
}
