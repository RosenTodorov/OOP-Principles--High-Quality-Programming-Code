using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergedLists
{
    public class Student : Human
    {
        // field       
        public float grade;      
        
        // constructor       
        public Student(string firstName, string lastName, float grade) : base(firstName, lastName)       
        {          
            this.grade = grade;       
        }      
        // property     
        public float Grade    
        {         
            get { return this.grade; }      
            set { this.grade = value; }    
        }        
        // overriding ToString     
        public override string ToString()    
        {           
            var builder = new StringBuilder();      
            builder.AppendFormat("{0} {1} {2,3:F2}", this.FirstName, this.LastName, this.grade);       
            return builder.ToString();     
        }   
    }
}


