using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat, ISound 
    { 
        public Tomcat(string name, byte age) : base(name, age, SexEnum.male) 
        { 

        } 

        public override void MakeSomeNoise()
        { 
            Console.WriteLine("Myaaaaaau- Myaaaauuu!"); 
        } 
    }
}