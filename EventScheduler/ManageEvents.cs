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


/**
 * 
 *  Manage Events and Automatic Checking For Overdue Events
 *  Funcrtional Requirement 6
 *  Used Disconnected Mode
 * 
**/

namespace EventScheduler
{
    public partial class ManageEvents : Form
    {
        public ManageEvents()
        {
            InitializeComponent();
        }

        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        private void ManageEvents_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl; User Id=ziad; Password=ziad;";
            string cmdstr = "SELECT* FROM events_table";
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGrid.DataSource = ds.Tables[0];
            check_overdue();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            check_overdue();
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("Updates Saved");

        }

        private void check_overdue()
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DateTime eventDate = Convert.ToDateTime(row["event_date"]);
                if (eventDate < DateTime.Now && row["status"].ToString() != "ended" && row["status"].ToString() != "canceled")
                {
                    row["status"] = "overdue";
                }
            }

            dataGrid.DataSource = ds.Tables[0];
            foreach (DataGridViewRow gridRow in dataGrid.Rows)
            {
                if (gridRow.Cells["STATUS"].Value == "overdue")
                    gridRow.DefaultCellStyle.BackColor = Color.Red;
            }
        }


        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGrid.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["id"].ToString() == row.Cells["id"].Value.ToString())
                            {
                                dr.Delete();
                                break;
                            }
                        }
                    }
                }

                builder = new OracleCommandBuilder(adapter);
                adapter.Update(ds.Tables[0]);

                ds.Tables[0].AcceptChanges();
                dataGrid.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
            check_overdue();
        }
    }
}
