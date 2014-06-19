using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Cat : Animal, ISound
    { 
        public Cat(string name, byte age, SexEnum gender) : base(name, age, gender) 
        { 

        } 
        public override void MakeSomeNoise() 
        { 
            Console.WriteLine("Some noise"); 
        } 
    }
}