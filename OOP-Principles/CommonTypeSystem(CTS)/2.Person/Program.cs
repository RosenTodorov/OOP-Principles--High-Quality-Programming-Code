using System;
using System.Collections.Generic;
using System.Linq;

/* 4.Create a class Person with two fields – name and age. Age can be left 
   unspecified (may contain null value. Override ToString() to display the 
   information of a person and if age is not specified – to say so. Write a program to test this functionality. */

namespace _2.Person
{
    class Program
    {
        static void Main()
        {
            Person firstPerson = new Person("Rosen", 56);
            Person secondPerson = new Person("Petar");

            Console.WriteLine(firstPerson.ToString());
            Console.WriteLine(secondPerson.ToString());
        }
    }
}
