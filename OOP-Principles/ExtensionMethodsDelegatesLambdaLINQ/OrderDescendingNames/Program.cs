using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in 
   descending order. Rewrite the same with LINQ. */

namespace OrderDescendingNames
{
    class Program
    {
        static void Main()
        {
            var students = new[] {
                new { FirstName = "Ivan", LastName = "Aleksandrov", Age = 28},
                new { FirstName = "Nikolay", LastName = "Stoyanov", Age = 15},
                new { FirstName = "Daniel", LastName = "Terziev", Age = 19},
                new { FirstName = "Vasil", LastName = "Antonov", Age = 22},
            };

            var orderByExtension = students.OrderByDescending(first => first.FirstName).ThenByDescending(last => last.LastName);
            var orderByLING =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            PrintNames(orderByExtension);
            Console.WriteLine();
            PrintNames(orderByLING);
        }

        private static void PrintNames(IEnumerable array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
	



