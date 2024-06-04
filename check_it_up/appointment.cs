using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace check_it_up
{
    public partial class appointment : Form
    {
        public appointment()
        {
            InitializeComponent();
            guna2DateTimePicker3.Format = DateTimePickerFormat.Time;
            guna2DateTimePicker3.ShowUpDown = true;
        }

        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost; uid=root; pwd=; database=check_it_up;";
            return new MySqlConnection(connectionString);
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void appointment_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string name = nametext.Text;
            string age = agetext.Text;
            string address = addresstext.Text;
            string concern = concerntext.Text;
            
            

            if (name == ""  || age == "" || address == " " || concern == " ")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO `appointment`( `name`, `birthdate`, `age`, `address`, `concern`, `date`, `time`, `doctors`) VALUES (@nametext,'" + this.guna2DateTimePicker2.Text+ "',@agetext,@addresstext,@concerntext,'" + this.guna2DateTimePicker1.Text+ "','" + this.guna2DateTimePicker3.Text+ "', '"+this.guna2ComboBox1.Text+"')";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nametext", name);
                    cmd.Parameters.AddWithValue("@agetext", age);
                    cmd.Parameters.AddWithValue("@addresstext", address);
                    cmd.Parameters.AddWithValue("@concerntext", concern);                  
                    


                    // Note: Consider hashing passwords in a real application
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Appointment Already Set!");
                        login lgf = new login();
                        lgf.Show();
                        this.Close();
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

        private void agetext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nametext_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2ComboBox1.Text = guna2ComboBox1.SelectedItem.ToString();
        }
    }
}
