using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Student : People
    {
        //field 
        private readonly int uniqueClassNumber;

        //constructor
        public Student(string name, int classNumber)
            : base(name)
        {
            if (classNumber > 0)
                this.uniqueClassNumber = classNumber;
            else
                throw new ArgumentException("Unappropriate classnumber");
        }

        //property
        public int ClassNumber
        {
            get { return this.uniqueClassNumber; }
        }
    }
}
