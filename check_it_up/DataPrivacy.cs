using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace check_it_up
{
    public partial class DataPrivacy : Form
    {
        public DataPrivacy()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            submitdata.Enabled = false;
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
     

            if (checkBox1.Checked == false)
            {
                submitdata.Enabled = false;
            }
            else
            {
                submitdata.Enabled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            user uss = new user();
            uss.Show();
            this.Hide();
        }
    }
}
