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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            appointment dc = new appointment();
            dc.TopLevel = false;
            ProfilePanel.Controls.Clear();
            ProfilePanel.Controls.Add(dc);
            dc.BringToFront();
            dc.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            
            DataPrivacy dp = new DataPrivacy();
            dp.Show();

            profile prof = new profile();
            prof.TopLevel = false;
            ProfilePanel.Controls.Clear();
            ProfilePanel.Controls.Add(prof);
            prof.BringToFront();
            prof.Show();
        }

        private void ProfilePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click_1(object sender, EventArgs e)
        {
            Doctors doctor = new Doctors();
            doctor.TopLevel = false;
            ProfilePanel.Controls.Clear();
            ProfilePanel.Controls.Add(doctor);
            doctor.BringToFront();
            doctor.Show();
        }
    }
}
