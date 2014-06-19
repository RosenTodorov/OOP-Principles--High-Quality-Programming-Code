using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class People
    {
        //field
        private string name;

        //class's constructor
        public People(string name)
        {
            if (name.Length > 2)
            {
                this.name = name;
            }
            else
                throw new ArgumentException("The name is too short");
        }

        //property 
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length > 4)
                    this.name = value;
                else
                    throw new ArgumentException("The name is too short");
            }
        }
    }
}


