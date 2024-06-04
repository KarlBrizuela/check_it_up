using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace check_it_up
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

            analytics anal = new analytics();
            anal.TopLevel = false;
            dashPanel.Controls.Clear();
            dashPanel.Controls.Add(anal);
            anal.BringToFront();
            anal.Show();


        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
             DoctorList dl = new DoctorList();
             dl.TopLevel = false;
            dashPanel.Controls.Clear();
            dashPanel.Controls.Add(dl);
            dl.BringToFront();
            dl.Show();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            patientlist pl = new patientlist();
            pl.TopLevel = false;
            dashPanel.Controls.Clear();
            dashPanel.Controls.Add(pl);
            pl.BringToFront();
            pl.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            login lgg = new login();
            lgg.Show();
            this.Hide();
        }

        private void dashPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            AccountDatabase ac = new AccountDatabase();
            ac.TopLevel = false;
            dashPanel.Controls.Clear();
            dashPanel.Controls.Add(ac);
            ac.BringToFront();
            ac.Show();
        }
    }
}
