using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events 
{ 
    public class CustomEvent : EventArgs 
    { 
        private string message; 

        public CustomEvent(string s)
        { 
            message = s; 
        } 

        public string Message 
        {
            get { return message; } 
            set { message = value; } 
        } 
    } 
}
