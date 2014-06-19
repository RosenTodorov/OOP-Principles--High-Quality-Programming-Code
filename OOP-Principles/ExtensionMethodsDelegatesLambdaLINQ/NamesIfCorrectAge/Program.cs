using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamesIfCorrectAge
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

            var getNames = from student in students
                           where student.Age > 18 && student.Age < 25
                           select new { student.FirstName, student.LastName };
            PrintNames(getNames);
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



