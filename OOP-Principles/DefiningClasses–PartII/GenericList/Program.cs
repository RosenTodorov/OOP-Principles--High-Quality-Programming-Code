using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericList
{
    class Program
    {
        static void Main()
        {
            GenericList<int> rt = new GenericList<int>(8);
            for (int i = 0; i < 99; i++)
            {
                rt.AddElement(i);
               
            }
            rt.InsertElement(67, 904);
            rt.InsertElement(100, -1);

            Console.WriteLine(rt.Min());
            Console.WriteLine(rt.Max());
            Console.WriteLine(rt.ToString());
        }
    }
}
