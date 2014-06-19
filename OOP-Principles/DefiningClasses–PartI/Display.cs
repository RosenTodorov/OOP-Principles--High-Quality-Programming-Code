using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses_PartI
{
    class Display
    {
        // Declaring the private field members
        private int? size;
        private int? numberOfColors;

        // Defining constructors
        public Display(int size, int numberOfColors)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }

        public Display(int? size)
        {
            this.size = size;
            this.numberOfColors = null;
        }

        public Display(int numberOfColors)
        {
            this.size = null;
            this.numberOfColors = numberOfColors;
        }

        // Defining properties
        public int? Size
        {
            get { return this.size; }
            set
            {
                if (value == null || value >= 0)
                    this.size = value;
                else
                    throw new ArgumentException();
            }
        }

        public int? NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value == null || value >= 0)
                    this.numberOfColors = value;
                else
                    throw new ArgumentException();
            }
        }
    }
}
