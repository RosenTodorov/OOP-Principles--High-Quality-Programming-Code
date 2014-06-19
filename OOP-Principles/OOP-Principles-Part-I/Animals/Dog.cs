using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Dog : Animal, ISound 
    { 
        public Dog(string name, byte age, SexEnum gender) : base(name, age, gender)
        { 

        } 

        public override void MakeSomeNoise()
        { 
            Console.WriteLine("Wuf - wuff!");
        }
    }
}

