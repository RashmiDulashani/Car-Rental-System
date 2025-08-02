using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Car_Rental_System
{
    public partial class Customer : Form
    {
        // Create a list to store all customers temporarily in memory
        List<Customer1> customerList = new List<Customer1>();
        public Customer()
        {
            InitializeComponent();
            DisplayHeaders();
            DisplayInfo();
            UpdateGrid();
        }


        private void DisplayHeaders()
        {
            UserDGV.EnableHeadersVisualStyles = false;  //Allow custom styles

            UserDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Britannic", 10, FontStyle.Bold);
            UserDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            UserDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            UserDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //UserDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //UserDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserDGV.AutoGenerateColumns = false;
            UserDGV.Columns.Clear();


            //Add columns manually with headers and property bindings
            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Customer ID",
                DataPropertyName = "Id"
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Customer Name",
                DataPropertyName = "Name"
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Address",
                DataPropertyName = "address"
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Contact",
                DataPropertyName = "contact"
            });
        }


        public void DisplayInfo()
        {
            Customer1 newCustomer1 = new Customer1(1, "Sahan", "Mathugama", 0765486253);
            Customer1 newCustomer2 = new Customer1(2, "Kasun", "Colombo", 0745324788);
            Customer1 newCustomer3 = new Customer1(3, "Tharush", "Kalutara", 0715475222);

            customerList.Add(newCustomer1);
            customerList.Add(newCustomer2);
            customerList.Add(newCustomer3);
        }


        // This method is triggered when Add button is clicked
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check if any of the input fields are empty
            if (CusId.Text == "" || CusName.Text == "" || CusAdd.Text == "" || Contact.Text == "")
            {
                MessageBox.Show("Missing Information. Please fill in all fields!");
            }
            else
            {
                // Create a variables and assign values from text boxes
                int id = int.Parse(CusId.Text);
                string name = CusName.Text;
                string address = CusAdd.Text;
                int contact = int.Parse(Contact.Text);

                // Add the new customer to the customer list
                Customer1 newCustomer = new Customer1(id, name, address, contact);
                customerList.Add(newCustomer);

                UpdateGrid();
                ClearData();
            }
        }


        //Refresh DataGridView
        private void UpdateGrid()
        {
            UserDGV.DataSource = null;   //This disconnects the current data source from the DataGridView
            UserDGV.DataSource = customerList; //This reconnects the updated list

        }


        //Clear text boxes after adding
        private void ClearData()
        {
            CusId.Clear();
            CusName.Clear();
            CusAdd.Clear();
            Contact.Clear();
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (UserDGV.SelectedRows.Count > 0)
            {
                int index = UserDGV.CurrentRow.Index;
                customerList.RemoveAt(index);

                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Select a row to delete!");
            }
        }


        private void BackBtn_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
