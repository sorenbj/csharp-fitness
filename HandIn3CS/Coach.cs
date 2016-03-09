using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandIn3CS
{
    [Serializable]

    public class Coach : Person
    {
        // instance variables
        private string eventType;

        // constructor
        public Coach(int staffNumber, string name, string gender, string password, string email, string role, string eventType) : base(staffNumber, name, gender, password, email, role)
        {
            this.eventType = eventType;
        }

        //EventType property
        public string EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        // ToString method - override standard build ToString method
        public override string ToString()
        {
            return "Staffnumber: " + staffNumber + " Name: " + name + " Gender: " + gender + " Password: " + password + " E-mail: " + email + " Role: " + role + " Event Type: " + eventType;
        }
    }
}