using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractClassShape
{
    public class Circle : Shape
    {
        public const double Pi = Math.PI;

        public Circle(double radius)
            : base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            return (double)(Pi * this.height * this.width);
        }
    }
}

