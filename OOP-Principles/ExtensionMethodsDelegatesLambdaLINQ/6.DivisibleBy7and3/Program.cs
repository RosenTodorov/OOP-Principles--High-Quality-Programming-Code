using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 6.Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension
  methods and lambda expressions. Rewrite the same with LINQ. */

namespace DivisibleBy7and3
{
    class Program
    {
        static void Main()
        {
            int[] arrayOfIntegers = new int[] { 6, 16, 7, 2, 0, 21, 56, 42, 57, 84 };

            var firstDivisibleDigits = arrayOfIntegers.Where(b => (b % 3 == 0) && (b % 7 == 0) && (b != 0));

            PrintDivisibleDigits(firstDivisibleDigits);
            Console.WriteLine();

            var secondDivisibleDigits =
                from number in arrayOfIntegers
                where number % 3 == 0 && number % 7 == 0 && number != 0
                select number;
            PrintDivisibleDigits(secondDivisibleDigits);
            Console.WriteLine();
        }

        private static void PrintDivisibleDigits(IEnumerable array)
        {
            foreach (var number in array)
            {
                Console.Write("{0} ", number);
            }
        }
    }
}
                
            


