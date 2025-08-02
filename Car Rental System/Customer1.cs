using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System
{
    internal class Customer1 : Person
    {
        //Encapsulation
        public string Address { get; set; }
        public int Contact { get; set; }

        //Parameterized Constructor
        public Customer1(int id, string name, string address, int contact) : base(id, name)
        {
            this.Address = address;
            this.Contact = contact;
        }
    }
}
