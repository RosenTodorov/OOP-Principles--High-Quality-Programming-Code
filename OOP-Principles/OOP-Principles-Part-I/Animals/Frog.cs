using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Frog : Animal, ISound
    { 
        public Frog(string name, byte age, SexEnum gender) : base(name, age, gender) 
        { 

        } 
        public override void MakeSomeNoise() 
        { 
            Console.WriteLine("ikk, ikk, hhh !");
        } 
    }
}
