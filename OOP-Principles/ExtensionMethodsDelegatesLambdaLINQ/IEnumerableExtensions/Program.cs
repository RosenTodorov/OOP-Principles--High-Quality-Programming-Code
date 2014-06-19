using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 2. Implement a set of extension methods for IEnumerable<T> 
  that implement the following group functions: sum, product, min, max, average. */

namespace IEnumerableExtensions
{
    class Program
    {
        static void Main()
        {
            List<double> list = new List<double>();

            list.Add(9);
            list.Add(1314);
            list.Add(36);
            list.Add(89329);
            list.Add(-3);

            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Product());
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Average());
        }
    }
}


