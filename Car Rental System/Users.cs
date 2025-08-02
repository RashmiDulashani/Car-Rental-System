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
    public partial class Users : Form
    {
        // Create a list to store all users temporarily in memory
        List<User> userList = new List<User>();
        public Users()
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
            UserDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UserDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserDGV.AutoGenerateColumns = false;
            UserDGV.Columns.Clear();


            //Add columns manually with headers and property bindings
            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "User ID",
                DataPropertyName = "Id"  
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "User Name",
                DataPropertyName = "Name"
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Password",
                DataPropertyName = "Password"
            });
        }

        
        public void DisplayInfo()
        {
            User newUser1 = new User(1, "Rashmi", "1235");
            User newUser2 = new User(2, "Sandun", "4568");

            userList.Add(newUser1);
            userList.Add(newUser2);
        }


        // This method is triggered when Add button is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            // Check if any of the input fields are empty
            if (UserId.Text == "" || UserName.Text == "" || UserPass.Text == "")
            {
                MessageBox.Show("Missing Information. Please fill in all fields!");
            }
            else
            {
               // Create a variables and assign values from text boxes
               int id = int.Parse(UserId.Text);
               string name = UserName.Text;
               string password = UserPass.Text;

               // Add the new user to the user list
               User newUser = new User(id, name, password);
               userList.Add(newUser);

               UpdateGrid();
               ClearData();   
            }
        }


        //Refresh DataGridView
        private void UpdateGrid()
        {
            UserDGV.DataSource = null;   //This disconnects the current data source from the DataGridView
            UserDGV.DataSource = userList; //This reconnects the updated list

        }


        //Clear text boxes after adding
        private void ClearData()
        {
            UserId.Clear();
            UserName.Clear();
            UserPass.Clear();
        }


        // This method is triggered when Delete button is clicked
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (UserDGV.SelectedRows.Count > 0)
            {
                int index = UserDGV.CurrentRow.Index;
                userList.RemoveAt(index);

                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Select a row to delete!");
            }
        }


        // This method is triggered when Back button is clicked
        private void BackBtn_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }


        // This method is triggered when Exit button is clicked
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
