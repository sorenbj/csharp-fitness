using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandIn3CS
{
    [Serializable]

    public abstract class Person
    {
        // Instance variables
        public int staffNumber;
        public string name;
        public string gender;
        public string password;
        public string email;
        public string role;

        // Constructor - code used when creating an object
        public Person(int staffNumber, string name, string gender, string password, string email, string role)
        {
            // assign person object member variables to constructor parameters
            this.staffNumber = staffNumber;
            this.name = name;
            this.gender = gender;
            this.password = password;
            this.email = email;
            this.role = role;
        }

        //Change email method
        public virtual string ChangeEmail(string email)
        {
            return this.Email = email;
        }

        //StaffNumber property
        public int StaffNumber
        {
            get { return staffNumber; }
            set { staffNumber = value; }
        }

        //Name property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Gender property
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        //Password property
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        //Email property
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // Role property
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        // ToString method - override standard build ToString method
        public override string ToString()
        {
            return "Staffnumber: " + staffNumber + " Name: " + name + " Gender: " + gender + " Password: " + password + " E-mail: " + email + " Role: " + role;
        }
    }
}