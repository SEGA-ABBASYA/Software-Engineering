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

namespace EventScheduler
{
    public partial class GenerateReportForm : Form
    {
        Report report;
        public GenerateReportForm()
        {
            InitializeComponent();
        }

        private void GenerateReportForm_Load(object sender, EventArgs e)
        {
            report = new Report();
            foreach(ParameterDiscreteValue val in report.ParameterFields[1].DefaultValues)
            {
                LocationCombo.Items.Add(val.Value);
            }
        }

        private void GenerateFormButton_Click(object sender, EventArgs e)
        {
            report = new Report();
            foreach (ParameterDiscreteValue val in report.ParameterFields[1].DefaultValues)
            {
                LocationCombo.Items.Add(val.Value);
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
