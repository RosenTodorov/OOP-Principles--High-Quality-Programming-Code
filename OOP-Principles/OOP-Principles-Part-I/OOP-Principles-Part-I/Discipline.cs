using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Discipline
    {
        //class's fields
        private Disciplines name;
        private int numberOfLectures;
        private int numberOfExercises;

        //class's constructor
        public Discipline(Disciplines name, int numberOfLectures, int numberOfExercises)
        {
            this.name = name;
            this.numberOfLectures = numberOfLectures;
            this.numberOfExercises = numberOfExercises;
            if (this.numberOfExercises <= 0 || this.numberOfLectures <= 0)
                throw new ArgumentException("Discipline mismatch");
        }

        //properties
        public Disciplines Name
        {
            get { return this.name; }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set
            {
                if (value > 0)
                    this.numberOfLectures = value;
                else
                    throw new ArgumentException("Discipline mismatch");
            }
        }

        public int NumberOfExercises
        {
            get { return this.numberOfExercises; }
            set
            {
                if (value > 0)
                    this.numberOfExercises = value;
                else
                    throw new ArgumentException("Discipline mismatch");
            }
        }
    }
}

                
