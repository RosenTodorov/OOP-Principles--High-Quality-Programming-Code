namespace SchoolTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void School_AddingNotNullStudentListToSchool()
        {
            School publicSchool = new School();
            Assert.IsNotNull(publicSchool.Students);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_AddingStudentWIthTheSameUniqueNumber()
        {
            School mySchool = new School();
            Student pesho = new Student("pesho", 12345, mySchool);
            Student gosho = new Student("gosho", 12345, mySchool);
        }

        [TestMethod]
        public void Student_AddingStudentsWithDifferentCredentials()
        {
            School mySchool = new School();
            Student pesho = new Student("pesho", 12344, mySchool);
            Student gosho = new Student("gosho", 12345, mySchool);
            Assert.AreNotEqual(pesho.UniqueNumber, gosho.UniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_AddingStudentWithOutOfRangeNumberSmallerThan10000()
        {
            School mySchool = new School();
            for (int number = 99999; number > 0; number--)
            {
                Student gosho = new Student("gosho", number, mySchool);
            }

            //Assert.Fail("Student's number is out of range");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_AddingStudentWithOutOfRangeNumberBiggerThan99998()
        {
            School mySchool = new School();
            for (int number = 10000; number < 100000; number++)
            {
                Student gosho = new Student("gosho", 110000, mySchool);
            }

            //Assert.Fail("Student's number is out of range");
        }

        [TestMethod]
        public void Student_AddingStudentWithProperNumber()
        {
            School mySchool = new School();
            for (int number = 10000; number <= 99999; number++)
            {
                Student gosho = new Student("gosho", number, mySchool);
                Assert.IsTrue(gosho.UniqueNumber >= 10000 && gosho.UniqueNumber <= 99999);
            }
        }

         [TestMethod]
        public void Student_JoinCourse()
        {
            School mySchool = new School();
            Course biology = new Course();
            Student gosho = new Student("gosho", 48000, mySchool);
            gosho.JoinCourse(biology);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_EmptyNameTest()
        {
            School mySchool = new School();
            string[] names = new string[] { "pesho", "gosho", string.Empty, "tosho" };
            int[] numbers = new int[] { 10000, 10001, 99999, 50000 };

            for (int index = 0; index < names.Length; index++)
            {
                Student gosho = new Student(names[index], numbers[index], mySchool);
            }
        }

         [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Course_AddingMoreThan29Students()
        {
            School mySchool = new School();
            Course art = new Course();

            for (int i = 1; i <= 35; i++)
            {
                Student student = new Student("Ivan Ivanov", i + 10000, mySchool);
                student.JoinCourse(art);
            }

            Assert.Fail("Course takes only 29 students");
        }

         [TestMethod]
         public void Course_LeavingCourse()
         {
             School mySchool = new School();
             Course art = new Course();

             for (int i = 1; i <= 15; i++)
             {
                 Student student = new Student("Ivan Ivanov", i + 10000, mySchool);
                 student.JoinCourse(art);
                 student.LeaveCourse(art);
             }

             Assert.IsTrue(art.Members.Count == 0);
         }

         [TestMethod]
         public void Course_MembersListIsNOtNull()
         {
             Course art = new Course();
             Assert.IsNotNull(art.Members);
         }

         [TestMethod]
         public void School_CoursesIsNotNull()
         {
             School mySchool = new School();
             Assert.IsNotNull(mySchool.Courses);
         }
    }
}