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
using TheArtOfDevHtmlRenderer.Adapters;

namespace check_it_up
{
    public partial class AccountDatabase : Form
    {
        public AccountDatabase()
        {
            InitializeComponent();
        }


        MySqlConnection con = new MySqlConnection("Server=localhost;Database=check_it_up;Uid=root;Pwd=;");
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM sign_up WHERE CONCAT(`email`) like '%" + valueToSearch + "%'";
            command = new MySqlCommand(query, con);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxValueToSearch.Text.ToString();
            searchData(valueToSearch);
        }

        private void AccountDatabase_Load(object sender, EventArgs e)
        {
            searchData(" ");

            string connectionString = "Server=localhost;Database=check_it_up;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM sign_up", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridView1.DataSource = dataTable;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=check_it_up;Uid=root;Pwd=;";
            string usernameToDelete = textBoxValueToSearch.Text; // Assuming you have a TextBox named usernameTextBox

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM sign_up WHERE email = @username";
                using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", usernameToDelete);

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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
