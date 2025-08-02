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
    public partial class Car : Form
    {
        // Create a list to store all cars temporarily in memory
        List<Car1> carList = new List<Car1>(); 
        public Car()
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
                HeaderText = "Reg No",
                DataPropertyName = "regNo"
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Brand",
                DataPropertyName = "brand"
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Model",
                DataPropertyName = "model"
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Price (LKR/Day)",
                DataPropertyName = "price"
            });

            UserDGV.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Available",
                DataPropertyName = "isAvailable"
            });
        }


        public void DisplayInfo()
        {
            Car1 newCar1 = new Car1("WP-CAE1234", "Toyota", "Axio", 9000, true);
            Car1 newCar2 = new Car1("CP-KDH1234", "Nissan", "Leaf", 8500, true);
            Car1 newCar3 = new Car1("WP-CBZ7890", "Honda", "Vezel", 10000, false);
            Car1 newCar4 = new Car1("SP-KGF4321", "Suzuki", "Wagon R", 6000, true);
            Car1 newCar5 = new Car1("WP-ABC1234", "Perodua", "Bezza", 7500, false);

            carList.Add(newCar1);
            carList.Add(newCar2);
            carList.Add(newCar3);
            carList.Add(newCar4);
            carList.Add(newCar5);
        }


        // This method is triggered when Add button is clicked
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Check if any of the input fields are empty
            if (RegNo.Text == "" || Brand.Text == "" || Model.Text == "" || Price.Text == "" || Availability.Text == "")
            {
                MessageBox.Show("Missing Information. Please fill in all fields!");
            }
            else
            {
                // Create a variables and assign values from text boxes
                string id = RegNo.Text;
                string brand = Brand.Text;
                string model = Model.Text;
                double price = double.Parse(Price.Text);
                bool isAvailable = Availability.SelectedItem?.ToString() == "Available";

                // Add the new user to the user list
                Car1 newCar = new Car1(id, brand, model, price, isAvailable);
                carList.Add(newCar);

                UpdateGrid();
                ClearData();
            }
        }


        //Refresh DataGridView
        private void UpdateGrid()
        {
            UserDGV.DataSource = null;   //This disconnects the current data source from the DataGridView
            UserDGV.DataSource = carList; //This reconnects the updated list

        }


        //Clear text boxes after adding
        private void ClearData()
        {
            RegNo.Clear();
            Brand.Clear();
            Model.Clear();
            Price.Clear();
            Availability.Items.Clear();
        }


        // This method is triggered when Delete button is clicked
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (UserDGV.SelectedRows.Count > 0)
            {
                int index = UserDGV.CurrentRow.Index;
                carList.RemoveAt(index);

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
