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
    public partial class DoctorList : Form
    {
        public DoctorList()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            doctordata marcelodata = new doctordata();
            marcelodata.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            doctordata bugawandata = new doctordata();
            bugawandata.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            doctordata espinadata = new doctordata();
            espinadata.Show();
            this.Hide();
        }

        private void DoctorList_Load(object sender, EventArgs e)
        {

            searchData(" ");

            string connectionString = "Server=localhost;Database=check_it_up;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM appointment", connection);
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
            string query = "SELECT * FROM appointment WHERE CONCAT(`id`, `name`, `birthdate`, `age`, `address`, `concern`, `date`, `time`, `doctors`) like '%"+valueToSearch+"%' ";
            command = new MySqlCommand(query, con);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxValueToSearch.Text.ToString();
            searchData(valueToSearch);
        }

        private void textBoxValueToSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
