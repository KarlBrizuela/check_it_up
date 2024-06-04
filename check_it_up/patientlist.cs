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
using Mysqlx.Crud;


namespace check_it_up
{
    public partial class patientlist : Form
    {
        public patientlist()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void patientlist_Load(object sender, EventArgs e)
        {

            searchData(" ");

            string connectionString = "Server=localhost;Database=check_it_up;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM information", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridView1.DataSource = dataTable;
            }
        }


        MySqlConnection con = new MySqlConnection("Server=localhost;Database=check_it_up;Uid=root;Pwd=;");
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM information WHERE CONCAT(`name`) like '%"+valueToSearch+"%'";
            command = new MySqlCommand(query, con);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxValueToSearch.Text.ToString();
            searchData(valueToSearch);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=check_it_up;Uid=root;Pwd=;";
            string usernameToDelete = textBoxValueToSearch.Text; // Assuming you have a TextBox named usernameTextBox

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM information WHERE name = @name";
                using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", usernameToDelete);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No account found with the given username.");
                    }
                }
            }
        }
    }
}
