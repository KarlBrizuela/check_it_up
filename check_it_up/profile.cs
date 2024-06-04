using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace check_it_up
{
    public partial class profile : Form
    {
        public profile()
        {
            InitializeComponent();

        }

        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost; uid=root; pwd=; database=check_it_up;";
            return new MySqlConnection(connectionString);
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void profile_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = nametext.Text;
            string age = agetext.Text;
            
            string height = heighttext.Text;
            string weight = weighttext.Text;
            string address = addresstext.Text;

            if (name == "" ||  age == " " || height == " " || weight == " " || address == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO  information ( `name`, `gender`, `birthdate`, `age`, `bloodtype`, `height`, `weight`, `address`) VALUES (@nametext, '"+this.guna2ComboBox1.Text+"' , '" + this.guna2DateTimePicker1.Text+ "', @agetext, '"+this.guna2ComboBox2.Text+"', @heighttext, @weighttext, @addresstext)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nametext", name);
                    cmd.Parameters.AddWithValue("@agetext", age);
                    
                    cmd.Parameters.AddWithValue("@heighttext", height);
                    cmd.Parameters.AddWithValue("@weighttext", weight);
                    cmd.Parameters.AddWithValue("@addresstext", address); // Note: Consider hashing passwords in a real application
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Profile has been saved!!");
       
                    }
                    catch (MySqlException)
                    {
                        MessageBox.Show("Error");
                    }
                }
            }

        }

        private void nametext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gendertext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void agetext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void heighttext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void weighttext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void nametext_TextChanged(object sender, EventArgs e)
        {

        }

        private void birthdatetext_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            
            string name = nametext.Text;
            string age = agetext.Text;
            string height = heighttext.Text;
            string weight = weighttext.Text;
            string address = addresstext.Text;

            // SQL update statement
            string query = "UPDATE information SET name=@nametext, '" + this.guna2DateTimePicker1.Text+ "', '"+this.guna2ComboBox1.Text+ "', Age=@agetext, '"+this.guna2ComboBox2.Text+"' , Height=@heighttext, Weight=@weighttext, Address=@addresstext WHERE id=@idtext";

            // Create SQL Connection and Command
            using (SqlConnection connection = new SqlConnection("server=localhost; uid=root; pwd=; database=check_it_up;"))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters
                command.Parameters.AddWithValue("@nametext", name);
                command.Parameters.AddWithValue("@agetext", age);
                command.Parameters.AddWithValue("@heighttext", height);
                command.Parameters.AddWithValue("@weighttext", weight);
                command.Parameters.AddWithValue("@addresstext", address);

                // Open connection and execute command
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected + " row(s) updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

