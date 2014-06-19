using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergedLists
{
    public class Worker : Human
    {
        // fields      
        private float weekSalary;   
        private int workHoursPerDay;
      
        // constructor       
        public Worker(string firstName, string lastName, float weekSalary, int workHoursPerDay) : base(firstName, lastName)     
        {            
            this.weekSalary = weekSalary;     
            this.workHoursPerDay = workHoursPerDay;   
        }       

        // properties      
        public float WeekSalary     
        {          
            get { return this.weekSalary; }        
            set { this.weekSalary = value; }      
        }   
    
        public int WorkHoursPerDay     
        {            
            get { return this.workHoursPerDay; }    
            set { this.workHoursPerDay = value; }    
        }

        public float MoneyPerHour()
        {
            float result = this.weekSalary / this.workHoursPerDay; 

            return result; 
        }      

        public override string ToString() 
        {
            var builder = new StringBuilder(); 
            builder.AppendFormat("{0}  {1}  {2} | {3} | {4}", FirstName, LastName, weekSalary, workHoursPerDay, this.MoneyPerHour());

            return builder.ToString();
        }
    }
}

