using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses_PartI
{
    class Call
    {
        // Declaring private fields 
        private DateTime dateTime;
        private string phoneNumber;
        private int duration;

        // Declaring constructor
        public Call(DateTime dateAndTime, string number, int duration)
        {
            this.dateTime = dateAndTime;
            this.phoneNumber = number;
            this.duration = duration;
        }

        // Declaring properties
        public DateTime DateAndTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public int Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }
    }
}