using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 1. We are given a school. In the school there are classes of students. 
   Each class has a set of teachers. Each teacher teaches a set of disciplines. 
   Students have name and unique class number. Classes have unique text identifier. 
   Teachers have name. Disciplines have name, number of lectures and number of exercises. 
   Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block). 
   Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy 
   and create a class diagram with Visual Studio.*/

namespace School
{
    class Program
    {
        static List<Teacher> teachers = new List<Teacher>();
        static List<Student> studentsInClass = new List<Student>();

        static void Main()
        {
            SchoolClasses simpleClass = new SchoolClasses("23 \'A\'", teachers, studentsInClass);
            AddTeachersToList();
            AddStudents();
            Console.WriteLine(simpleClass.ToString());

            simpleClass.Teachers.Add(new Teacher("Rosen", new List<Discipline>() { new Discipline(Disciplines.Biology, 15, 10) }));
            simpleClass.Students.Add(new Student("Daniel", 9));
            Console.WriteLine(simpleClass.ToString());

        }

        private static void AddStudents()
        {
            studentsInClass.Add(new Student("Stoyan", 12));
            studentsInClass.Add(new Student("Aleksandra", 1));
            studentsInClass.Add(new Student("Viktor", 15));
        }

        private static void AddTeachersToList()
        {
            List<Discipline> teacherOneDisciplines = new List<Discipline>();
            teacherOneDisciplines.Add(new Discipline(Disciplines.Biology, 25, 20));
            teacherOneDisciplines.Add(new Discipline(Disciplines.Mathematics, 50, 45));
            teacherOneDisciplines.Add(new Discipline(Disciplines.Physics, 20, 19));

            List<Discipline> teacherTwoDisciplines = new List<Discipline>();
            teacherTwoDisciplines.Add(new Discipline(Disciplines.Arts, 40, 45));
            teacherTwoDisciplines.Add(new Discipline(Disciplines.Music, 40, 40));
            teacherTwoDisciplines.Add(new Discipline(Disciplines.Literature, 60, 60));
            
            List<Discipline> teacherThreeDisciplines = new List<Discipline>();
            teacherThreeDisciplines.Add(new Discipline(Disciplines.Sport, 40, 45));
            teacherThreeDisciplines.Add(new Discipline(Disciplines.OtherLanguage, 40, 40));

            teachers.Add(new Teacher("Ivan", teacherOneDisciplines));
            teachers.Add(new Teacher("Kiril", teacherThreeDisciplines));
            teachers.Add(new Teacher("Petar", teacherThreeDisciplines));
        }
    }
}
