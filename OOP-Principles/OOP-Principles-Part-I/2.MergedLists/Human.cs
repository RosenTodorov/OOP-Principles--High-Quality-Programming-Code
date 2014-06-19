using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergedLists
{
    public abstract class Human
    {
        //public string FirstName { get; protected set; }       
        //public string LastName { get; protected set; }

        private string firstName;
        public string FirstName 
        { 
            get { return firstName; } 
            set 
            { 
                if (value.Length > 2)                 
                    this.firstName = value; 
                else          
                    throw new ArgumentException("Input some correct firstname"); 
            } 
        }       
        
        private string lastName; 
        public string LastName 
        { 
            get { return lastName; }
            set 
            { 
                if (value.Length > 2) 
                    this.lastName = value;
                else                   
                    throw new ArgumentException("Input some correct lastname"); 
            } 
        }

        // Defining constructor, it is an abstract class, it can be easily inherited by other classes as base()    
        public Human(string firstName, string lastName)       
        {            
            this.firstName = firstName;       
            this.lastName = lastName;     
        }       
        public abstract override string ToString();      
    }
}


