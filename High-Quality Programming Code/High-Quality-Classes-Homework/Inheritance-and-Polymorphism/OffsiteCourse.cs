namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name)
            : base(name, null, new List<string>())
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName, new List<string>())
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public override string ToString()
        {
            var preResult = new StringBuilder();
            preResult.Append(base.ToString());

            if (this.ExtraInfo != null)
            {
                preResult.Append("; Town = ");
                preResult.Append(this.ExtraInfo);
            }

            preResult.Append(" }");

            return preResult.ToString();
        }
    }
}