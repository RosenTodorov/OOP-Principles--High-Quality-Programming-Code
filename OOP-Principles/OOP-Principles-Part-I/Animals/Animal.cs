using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Animal : ISound
    {
        public string name;      
        public byte age;      
        public SexEnum gender;   

        public Animal(string name, byte age, SexEnum gender)      
        {          
            this.name = name;           
            this.age = age;           
            this.gender = gender;     
        }      
  
        public string Name       
        {       
            get { return this.name; }     
            set { this.name = value; }     
        }        

        public SexEnum Gender      
        {        
            get { return this.gender; }        
            set { this.gender = value; }     
        }     
  
        public byte Age       
        {            
            get { return this.age; }    
            set { this.age = value; }    
        }      
  
        public virtual void MakeSomeNoise()    
        {           
            Console.WriteLine("Make a noise");     
        }   
    }
}

  
