using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventScheduler
{
    public partial class GenerateReport1Form : Form
    {
        CrystalReport1 report = new CrystalReport1();
        
        public GenerateReport1Form()
        {
            InitializeComponent();
        }

        private void GenerateReport1Form_Load(object sender, EventArgs e)
        {
            report.Refresh();
            report.SetParameterValue(0, "");
            Report1Viewer.ReportSource = report;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            report.Refresh();
            report.SetParameterValue(0, UserNameText.Text);
            Report1Viewer.ReportSource = report;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
