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
    public partial class UpcomingEvents : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        //OracleConnection conn;
        int userId;

        public UpcomingEvents()
        {
            InitializeComponent();
        }

        private void UpcomingEvents_Load(object sender, EventArgs e)
        {

            //try
            //{
            //    conn = new OracleConnection(ordb);
            //    conn.Open();

            //    string query = @"
            //        SELECT e.id, e.name, e.location, e.date, e.priority
            //        FROM events e
            //        JOIN participants p ON e.id = p.event_id
            //        WHERE p.user_id = :userId
            //          AND e.date > SYSDATE
            //        ORDER BY 
            //            CASE 
            //                WHEN e.priority = 'high' THEN 1
            //                WHEN e.priority = 'medium' THEN 2
            //                WHEN e.priority = 'low' THEN 3
            //                ELSE 4
            //            END";

            //    OracleCommand cmd = new OracleCommand(query, conn);
            //    cmd.Parameters.Add("userId", userId);

            //    OracleDataReader reader = cmd.ExecuteReader();

            //    // Setup DataGridView
            //    upcoming_datagridview.Rows.Clear();
            //    upcoming_datagridview.Columns.Clear();

            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        upcoming_datagridview.Columns.Add(reader.GetName(i), reader.GetName(i));
            //    }

            //    while (reader.Read())
            //    {
            //        object[] row = new object[reader.FieldCount];
            //        reader.GetValues(row);
            //        upcoming_datagridview.Rows.Add(row);
            //    }

            //    reader.Close();
            //    conn.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error loading events: " + ex.Message);
            //}
        }

        private void upcoming_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
