namespace School
{
    using System;
    using System.Linq;

    public class Student
    {
        private string name;
        private int uniqueNumber;
        private School school;

        public Student(string name, int number, School school)
        {
            this.School = school;
            this.Name = name;
            this.UniqueNumber = number;
            this.School.Students.Add(this.UniqueNumber, this);
        }

        public School School
        {
            get
            {
                return this.school;
            }

            set
            {
                this.school = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(value, "Name of student can not be empty");
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            private set
            {
                if (10000 > value || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Unique number must be between 10000 and 99999");
                }

                if (this.School.Students.ContainsKey(this.UniqueNumber))
                {
                    throw new ArgumentException("The unique number given to student already exists");
                }

                this.uniqueNumber = value;
            }
        }

        public void JoinCourse(Course course)
        {
            course.AddStudentToCourse(this.UniqueNumber, this);
        }

        public void LeaveCourse(Course course)
        {
            course.Members.Remove(this.UniqueNumber);
        }
    }
}         
