using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractClassShape
{
    public class Triangle : Shape
    {
        public Triangle(double height, double width)
            : base(height, width)
        {
        }

        public override double CalculateSurface()
        {
            return (double)((this.Height * this.Width) / 2);
        }
    }
}


    
