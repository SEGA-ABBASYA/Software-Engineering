using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Oracle.DataAccess.Client;


/**
 * 
 * Shows Events and its number of attendees
 * Calculate a summary for total revenue for the event
 * before and after calculating taxes
 * A summary field shows the most expensive ticket 
 * 
**/


namespace EventScheduler
{
    public partial class GenerateReportForm : Form
    {
        String ordb = "Data Source=orcl;User Id=hr;Password=hr";
        OracleConnection conn;
        OracleCommand cmd;
        Report report = new Report();


        public GenerateReportForm()
        {
            InitializeComponent();
        }

        private void GenerateReportForm_Load(object sender, EventArgs e)
        {
            report.Refresh();
            report.SetParameterValue("Minimmum Attendees", 0);
            report.SetParameterValue("Location", "");

            ReportViewer.ReportSource = report;
           
            conn = new OracleConnection(ordb);
            cmd = new OracleCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT DISTINCT location FROM EVENTS_TABLE";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LocationCombo.Items.Add(reader.GetString(0));
            }

        }

        private void GenerateFormButton_Click(object sender, EventArgs e)
        {

            report.Refresh();
            
            LocationCombo.Items.Clear();
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LocationCombo.Items.Add(reader.GetString(0));
            }

            report.SetParameterValue(0, minAttendeesText.Text);
            report.SetParameterValue(1, LocationCombo.Text);
            
            ReportViewer.ReportSource = report; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
