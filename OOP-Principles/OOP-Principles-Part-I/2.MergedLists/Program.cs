using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/* 2. Define abstract class Human with first name and last name. 
 * Define new class Student which is derived from Human and has new field – grade. 
 * Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() 
 * that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy. 
 * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method). 
 * Initialize a list of 10 workers and sort them by money per hour in descending order. 
 * Merge the lists and sort them by first name and last name.*/

namespace MergedLists
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            List<Student> students = new List<Student>();
            students.Add(new Student("Rosen", "Todorov", 5.60f)); 
            students.Add(new Student("Mihail", "Petrov", 3.00f)); 
            students.Add(new Student("Gosho", "Stefanov", 4.750f)); 
            students.Add(new Student("Sasho", "Mashov", 2.00f));
            students.Add(new Student("Kiro", "Drynov", 6.00f)); 
            students.Add(new Student("Peter", "Ligvo", 3.50f)); 
            students.Add(new Student("Kolio", "Vehtev", 4.73f)); 
            students.Add(new Student("Blagoi", "Mitrev", 4.00f));
            students.Add(new Student("Niki", "Tokmakchiev", 5.50f));
            students.Add(new Student("Jonathan", "Camby", 5.25f));

            var orderedStudents = students.OrderBy(student => student.Grade); 
            Console.WriteLine("Students"); 
            foreach (var student in orderedStudents) 
            { 
                Console.WriteLine(student.ToString());
            } 
            Console.WriteLine(); 
            
            List<Worker> workers = new List<Worker>(); 
            workers.Add(new Worker("Peter", "Georgiev", 127, 8));
            workers.Add(new Worker("Kolio", "Vehtev", 432, 8));
            workers.Add(new Worker("Niki", "Mitrev", 550, 12));
            workers.Add(new Worker("Sasho", "Mashov", 342, 10));
            workers.Add(new Worker("Mihail", "Tokmakchiev", 562, 11));
            workers.Add(new Worker("Jonathan", "Stefanov", 200, 9));
            workers.Add(new Worker("Blagoi", "Camby", 800, 6));
            workers.Add(new Worker("Gosho", "Petrov", 150, 8));
            workers.Add(new Worker("Rosen", "Drynov", 190, 10));
            workers.Add(new Worker("Kiro", "Todorov", 340, 5));

            var descendedWorkers = workers.OrderByDescending(x => x.MoneyPerHour()); 
            Console.WriteLine("Workers");
            foreach (var worker in descendedWorkers) 
            { 
                Console.WriteLine(worker.ToString()); 
            } 
            Console.WriteLine(); 

            List<Human> mergedList = new List<Human>(); 
            mergedList.AddRange(orderedStudents); 
            mergedList.AddRange(descendedWorkers); 

            var final = mergedList.OrderBy(element => element.FirstName).ThenBy(element => element.LastName); 
            Console.WriteLine("Final Result");           
            foreach (var item in final)
            { 
                Console.WriteLine(item.ToString()); 
            }
        }
    }
}
