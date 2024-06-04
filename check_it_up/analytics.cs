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
    public partial class analytics : Form
    {
        public analytics()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=check_it_up;Uid=root;Pwd=;";

            string query = "SELECT COUNT(*) FROM sign_up";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    object result = cmd.ExecuteScalar();
                    int count = Convert.ToInt32(result);

                    // Display the count in the label
                    label2.Text = count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void analytics_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=check_it_up;Uid=root;Pwd=;";

            string query = "SELECT COUNT(*) FROM sign_up";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    object result = cmd.ExecuteScalar();
                    int count = Convert.ToInt32(result);

                    // Display the count in the label
                    label2.Text = count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
