using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System
{
    internal class Car1
    {
        //Encapsulation
        public string RegNo{ get; set; }
        public string Brand{ get; set; }
        public string Model{ get; set; }
        public double Price{ get; set; }
        public bool IsAvailable{ get; set; }

        //Parameterized Constructor
        public Car1(string regNo, string brand, string model, double price, bool isAvailable)
        {
            this.RegNo = regNo;
            this.Brand = brand;
            this.Model = model; 
            this.Price = price;
            this.IsAvailable = isAvailable;
        }
    }
}
