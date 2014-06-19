namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private IList<Course> courses;
        private IDictionary<int, Student> students;

        public School()
        {
            this.courses = new List<Course>();
            this.students = new Dictionary<int, Student>();
        }

        public IList<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public IDictionary<int, Student> Students
        {
            get
            {
                return this.students;
            }
        }
    }
}