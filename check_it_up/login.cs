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
using System.Data.SqlClient;
using System.Security.Cryptography;



namespace check_it_up
{
    public partial class login : Form

        
    { 
        public login()
        {
            InitializeComponent();
        }

        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost; uid=root; pwd=; database=check_it_up;";
            return new MySqlConnection(connectionString);
        }
        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void show_Click(object sender, EventArgs e)
        {
            
        }

        private void hide_Click(object sender, EventArgs e)
        {
            if(Password.PasswordChar == '0')
            {
                show.BringToFront();
                Password.PasswordChar = '*';
            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void show_Click_1(object sender, EventArgs e)
        {
            if (Password.PasswordChar == '*')
            {
                hide.BringToFront();
                Password.PasswordChar = '\0';
            }
        }

        private void hide_Click_1(object sender, EventArgs e)
        {
            if (Password.PasswordChar == '\0')
            {
                show.BringToFront();
                Password.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp sp = new SignUp();
            sp.Show();
            this.Hide();
        }
        



        private void gunaButton1_Click(object sender, EventArgs e)
        {
           

            string email = username.Text;
            string password = Password.Text;
            if (email == "" || password == "")
            {
                MessageBox.Show("please all the field");
                return;
            }
            
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM sign_up WHERE email = @email AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        user fillupform = new user();
                        fillupform.Show();
                        this.Hide();
                    }
                    else if (email == "admin" && password == "admin12")
                    {

                        Dashboard ds = new Dashboard();
                        ds.Show();
                        this.Hide();
                    }
                   
                    else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }

          
            
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void show_Click_2(object sender, EventArgs e)
        {
            if (Password.PasswordChar == '*')
            {
                hide.BringToFront();
                Password.PasswordChar = '\0';
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SendCode sdd = new SendCode();
            sdd.Show();
        }
    }
}
