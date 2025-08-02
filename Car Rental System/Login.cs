using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //private void LoginBtn_Click(object sender, EventArgs e)
        //{
        //    string username = LoginUsername.Text.Trim(); // fixed name & trimmed
        //    string password = LoginPassword.Text.Trim();

        //    if (username == "admin" && password == "123rsh")
        //    {
        //        MainForm main = new MainForm();
        //        main.Show();
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid Credentials!");
        //    }
        //}

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            string username = LoginUsername.Text;
            string password = LoginPassword.Text;

            if (username == "admin" && password == "1234")
            {
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Credentials!");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
