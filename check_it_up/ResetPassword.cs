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
using Mysqlx.Crud;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;


namespace check_it_up
{
    public partial class ResetPassword : Form
    {
        String name =  SendCode.to;
        public MySqlConnection GetConnection()
        {
            string connectionString = "server=localhost; uid=root; pwd=; database=check_it_up;";
            return new MySqlConnection(connectionString);
        }
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string email = username.Text;
            string password = passwordtext.Text;

            if (email == "" || password == "" )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO `sign_up`( `email`, `password`) VALUES (@username,@Password)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", email);
                    cmd.Parameters.AddWithValue("@Password", password); // Note: Consider hashing passwords in a real application
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Password has been updated");
                        login lgf = new login();
                        lgf.Show();
                        this.Close();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
                login ln = new login();
            ln.Show();  
            this.Close();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }
    }
    }

        
    

            

                
            

        
    


