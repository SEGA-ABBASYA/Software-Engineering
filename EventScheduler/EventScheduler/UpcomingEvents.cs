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
    public partial class UpcomingEvents : Form
    {
        string ordb = "Data Source=orcl;User Id=ziad;Password=ziad";
        OracleConnection conn;
        public UpcomingEvents()
        {
            InitializeComponent();
        }

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


        }

        private void UpcomingEvents_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
