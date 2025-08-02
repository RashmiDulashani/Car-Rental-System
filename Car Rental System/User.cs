using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System
{
    //This class represents a single user in the system
    internal class User : Person
    {
        public string Password { get; set; }

        //Parameterized Constructor
        public User(int id, string name, string password) : base(id, name)
        {
            this.Password = password;
        }
    }
}
