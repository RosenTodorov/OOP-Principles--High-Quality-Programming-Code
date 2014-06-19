using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Write a method that from a given array of students finds all students 
 whose first name is before its last name alphabetically. Use LINQ query operators. */

namespace StudentNames
{
    class Program
    {
        static void Main()
        {
            var students = new[] {
                new { FirstName = "Ivan", LastName = "Aleksandrov"},
                new { FirstName = "Nikolay", LastName = "Stoyanov"},
                new { FirstName = "Daniel", LastName = "Terziev"},
                new { FirstName = "Vasil", LastName = "Antonov"},
            };

            var sortedNames = from student in students
                              where student.FirstName.CompareTo(student.LastName) < 0
                              select student;
            PrintSortedNames(sortedNames);
        }

        private static void PrintSortedNames(IEnumerable array)
        {
            foreach (var names in array)
            {
                Console.WriteLine(names);
            }
        }
    }
}
                
 