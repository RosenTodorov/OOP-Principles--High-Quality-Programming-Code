namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            if (other == null)
            {
                throw new ArgumentException("No student to compare");
            }

            if (other.BirthDate == null || this.BirthDate == null)
            {
                throw new ArgumentException("Student must have set birthday dates, before compare");
            }

            return this.BirthDate < other.BirthDate;
        }
    }
}
