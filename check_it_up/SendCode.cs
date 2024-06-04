using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace check_it_up
{
    public partial class SendCode : Form
    {
        string randomCode;
        public static string to;
        public SendCode()
        {
            InitializeComponent();
        }

        private void SendCode_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string from, pass, messagebody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtmail.Text).ToString();
            from = "karl.brizuela01@gmail.com";
            pass = "qncc gdlj jrzn lddt";
            messagebody = "your reset code is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "password reseting code";
            SmtpClient smpt = new SmtpClient("smtp.gmail.com");
            smpt.EnableSsl = true;
            smpt.Port = 587;
            smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
            smpt.Credentials = new NetworkCredential(from, pass);
            try
            {
                smpt.Send(message);
                MessageBox.Show("Send Code successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (randomCode == (txtVerCode.Text).ToString())
            {
                to = txtmail.Text;
                ResetPassword rppp = new ResetPassword();
                this.Hide();
                rppp.Show(); 
            }
            else
            {
                MessageBox.Show("wrong code");
            }
            

        }
    }
}
