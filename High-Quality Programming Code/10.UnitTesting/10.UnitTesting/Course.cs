namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private IDictionary<int, Student> members;

        public Course()
        {
            this.members = new Dictionary<int, Student>();
        }

        public IDictionary<int, Student> Members
        {
            get
            {
                return this.members;
            }
        }

        public void AddStudentToCourse(int number, Student student)
        {
            if (this.members.Count > 30)
            {
                throw new InvalidOperationException("Course is full");
            }

            this.members.Add(number, student);
        }
    }
}