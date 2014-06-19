using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, byte age)
            : base(name, age, SexEnum.female)
        {

        }
        public override void MakeSomeNoise()
        {
            Console.WriteLine("Miau - miauu!");
        }
    }
}