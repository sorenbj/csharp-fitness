using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandIn3CS
{
    [Serializable]

    public class Administrator : Person
    {
        // instance variables
        private int level;

        // constructor
        public Administrator(int staffNumber, string name, string gender, string password, string email, string role, int level) : base(staffNumber, name, gender, password, email, role)
        {
            this.level = level;
        }

        //Level property
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public override string ChangeEmail(string email)
        {
            if (email.EndsWith("@fitness.dk"))
            {               
                return "ok";
            }
            else
            {             
                return "Error";
            }
        }

        // ToString method - override standard build ToString method
        public override string ToString()
        {
            return "Staffnumber: " + staffNumber + " Name: " + name + " Gender: " + gender + " Password: " + password + " E-mail: " + email + " Role: " + role + " Level: " + level;
        }
    }
}