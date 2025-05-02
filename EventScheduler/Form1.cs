using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 *
 * Main GUI Form
 *
 */

namespace EventScheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void create_event_btn_Click(object sender, EventArgs e)
        {
            CreateEvent create = new CreateEvent();
            this.Hide();
            create.ShowDialog();
            this.Show();
        }

        private void manage_event_btn_Click(object sender, EventArgs e)
        {
            ManageEvents manage = new ManageEvents();
            this.Hide();
            manage.ShowDialog();
            this.Show();
        }

        private void upcoming_events_btn_Click(object sender, EventArgs e)
        {
            UpcomingEvents upcoming = new UpcomingEvents();
            this.Hide();
            upcoming.ShowDialog();
            this.Show();
        }

        private void register_event_btn_Click(object sender, EventArgs e)
        {
            AllEvents events = new AllEvents();
            this.Hide();
            events.ShowDialog();
            this.Show();
        }

        private void crystal_1_Click(object sender, EventArgs e)
        {
            GenerateReport1Form cs1 = new GenerateReport1Form();
            this.Hide();
            cs1.ShowDialog();
            this.Show();

        }

        private void user_registiration_btn_Click(object sender, EventArgs e)
        {
            RegisterForm user = new RegisterForm();
            this.Hide();
            user.ShowDialog();
            this.Show();
        }

        private void crystal_2_Click(object sender, EventArgs e)
        {
            GenerateReportForm cs = new GenerateReportForm();
            this.Hide();
            cs.ShowDialog();
            this.Show();
        }
    }
}
