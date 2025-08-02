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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // This method is triggered when User button is clicked
        private void UserBtn_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }


        // This method is triggered when Car button is clicked
        private void CarBtn_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.Show();
            this.Hide();
        }


        // This method is triggered when Customer button is clicked
        private void CusBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(); 
            customer.Show();
            this.Hide();
        }


        // This method is triggered when Rental button is clicked
        private void RentBtn_Click(object sender, EventArgs e)
        {
            Rental rental = new Rental();   
            rental.Show();
            this.Hide();
        }


        // This method is triggered when Logout button is clicked
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }


        // This method is triggered when Exit button is clicked
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
