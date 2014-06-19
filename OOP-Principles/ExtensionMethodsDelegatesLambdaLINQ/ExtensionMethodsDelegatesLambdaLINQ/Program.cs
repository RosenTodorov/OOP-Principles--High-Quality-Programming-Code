using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 1. Implement an extension method Substring(int index, int length) for the class StringBuilder 
   that returns new StringBuilder and has the same functionality as Substring in the class String. */

namespace SubstringExtension
{
    class Program
    {
        static void Main()
        {
            var sb = new StringBuilder();

            sb.Append("I am what am I");

            Console.WriteLine(sb.Substring(3, 9));
        }
    }
}
