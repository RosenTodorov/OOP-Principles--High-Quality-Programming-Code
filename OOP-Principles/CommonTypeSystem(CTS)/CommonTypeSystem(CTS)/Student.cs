using System;
using System.Linq;
using System.Text;

namespace _1.Student
{
 /* 2.Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
    3.Implement the IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) 
    and by social security number (as second criteria, in increasing order).*/

    public class Student : ICloneable, IComparable<Student>
    {
        /* Define a class Student, which contains data about a student – first, middle and last name, SSN, 
         permanent address, mobile phone e-mail, course, specialty, university, faculty */

        //fields of the Student class
        private string firstName;
        private string middleName;
        private string lastName;
        private string SSN;
        private string permAddress;
        private string mobilePhone;
        private string email;
        private Course? course;
        private Faculty? faculty;
        private Specialty? specialty;
        private University? university;

        //constructors
        public Student(string firstName, string middleName, string lastName, string SSN, string permAddress,
            string mobilePhone, string email, Course? course, Faculty? faculty, Specialty? specialty, University? university)
        {
            try
            {
                this.firstName = firstName;
                this.middleName = middleName;
                this.lastName = lastName;

                if (SSN.Length == 10)
                {
                    this.SSN = SSN;
                }
                else
                    throw new ArgumentException("Invalid social security number");

                this.permAddress = permAddress;
                this.mobilePhone = mobilePhone;

                if (email != null)
                {
                    if (email.Contains("@"))
                    {
                        this.email = email;
                    }
                    else
                        throw new ArgumentException("Invalid e-mail");
                }

                this.course = course;
                this.faculty = faculty;
                this.specialty = specialty;
                this.university = university;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        public Student(string firstName, string middleName, string lastName, string SSN) : 
            this(firstName, middleName, lastName, SSN, null, null, null, null, null, null, null)
        {
        }

        public Student()
        {
        }

        //properties
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string ssn
        {
            get { return this.SSN; }
            set
            {
                try
                {
                    if (value.Length == 10)
                    {
                        this.SSN = value;

                    }
                    else
                        throw new ArgumentException("Invalid social security number");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        public string PermanentAddress
        {
            get { return this.permAddress; }
            set { this.permAddress = value; }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set { this.mobilePhone = value; }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                try
                {
                    if (value.Contains("@"))
                    {
                        this.email = value;
                    }
                    else
                        throw new ArgumentException("Invalid email");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        public Course? Course
        {
            get { return this.course; }
            set { this.course = value; }
        }

        public Faculty? Faculty
        {
            get { return this.faculty; }
            set { this.faculty = value; }
        }

        public University? University
        {
            get { return this.university; }
            set { this.university = value; }
        }

        public Specialty? Speciality
        {
            get { return this.specialty; }
            set { this.specialty = value; }
        }

        // Overriding Object Methods
        public override bool Equals(object param)
        {
            Student otherStudent = param as Student;
            return this.SSN == otherStudent.SSN;
        }

        /*
        public override bool Equals(object param)
        {   
           Student otherStudent = param as Student;

        if (otherStudent == null)
        {
            return false;
        }

        if (!Object.Equals(this.FirstName, student.FirstName))
        {
            return false;
        }

        if (!Object.Equals(this.LastName, student.LastName))
        {
            return false;
        }
        if (this.SSN != otherStudent.SSN)
        {
            return false;
        }

        return true;
    }

    public static bool operator ==(Student student1, Student student2)
    {
        return Student.Equals(student1, student2);
    }

    public static bool operator !=(Student student1, Student student2)
    {
        return !(Student.Equals(student1, student2));
    } */

        public override int GetHashCode()
        {
            return (this.SSN.GetHashCode() + this.firstName.GetHashCode()/2 + this.firstName.GetHashCode()/2);
        }

        /* public override int GetHashCode()
        {
            return firstName.GetHashCode() ^ lastName.GetHashCode() ^ ssn.GetHashCode();
        } */

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Student Info");            
            result.AppendFormat("Name: {0} {1} {2}\n\r", this.firstName, this.middleName,this.lastName);           
            result.AppendFormat("SSN: {0}\n\r", this.ssn);          
            if(!string.IsNullOrWhiteSpace(this.permAddress))         
                result.AppendFormat("Address: {0}\n\r", this.permAddress);          
            if(!string.IsNullOrWhiteSpace(this.mobilePhone))       
                result.AppendFormat("Mobile Phone: {0}\n\r", this.mobilePhone);       
            if(!string.IsNullOrWhiteSpace(this.email))              
                result.AppendFormat("Email: {0}\n\r", this.email);          
            if(this.course != null)            
                result.AppendFormat("Course: {0}\n\r", this.course);      
            if(this.faculty != null)          
                result.AppendFormat("Faculty: {0}\n\r", this.faculty);     
            if(this.specialty != null)            
                result.AppendFormat("Specialty: {0}\n\r", this.specialty);     
            if(this.university != null)       
                result.AppendFormat("University: {0}\n\r", this.university);      
            return result.ToString();      
        }

        public object Clone()
        {
            Student newStud = new Student();

            //newStud = this.MemberwiseClone() as Student;
            //return newStud;

            return new Student(this.firstName, this.middleName, this.lastName, this.ssn, this.permAddress, this.mobilePhone,
                this.email, this.course, this.faculty, this.specialty, this.university);
        }

        public int CompareTo(Student other)
        {
          /*if (firstName.CompareTo(other.firstName) != 0)
                return firstName.CompareTo(other.firstName);
            else if (middleName.CompareTo(other.middleName) != 0)
                return middleName.CompareTo(other.middleName);
            else if (lastName.CompareTo(other.lastName) != 0)
                return lastName.CompareTo(other.lastName);
            else
            {
                return ssn.CompareTo(other.SSN);
            } */

           // comparing two students if they are equal 0 is returned, else their three names and ssn are compared, after which -1 or 1 is returned         
           if (Student.Equals(this, other))             
           return 0;          
           return Student.Equals(new Student[] { this, other }.OrderBy(stud => stud.firstName).ThenBy(stud => stud.middleName).ThenBy(stud => stud.lastName).ThenBy(stud => stud.ssn).First(), this) ? -1 : 1;
        }

        //Overriding operators       
        public static bool operator ==(Student main, Student other)      
        {           
            return main.ssn == other.ssn;      
        }       
        public static bool operator !=(Student main, Student other)  
        {         
            return main.ssn != other.ssn;      
        }   
    }
}

        


         
         




                    
                    
              
                    









