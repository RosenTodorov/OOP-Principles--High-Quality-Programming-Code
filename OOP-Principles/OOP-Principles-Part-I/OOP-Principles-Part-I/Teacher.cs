using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Teacher : People
    {
        //field
        private IList<Discipline> disciplines;

        //constructor
        public Teacher(string name, IList<Discipline> collectionOfDisciplines)
            : base(name)
        {
            this.disciplines = collectionOfDisciplines;
        }

        //property
        public IList<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set
            {
                this.disciplines = value;
            }
        }
    }
}


