namespace Abstraction
{
    using System;
    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Circl's radius must be bigger than 0");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            if (this.Radius <= 0)
            {
                throw new ArgumentException("Circle's perimeter can not be calculated, because of invalid parameter");
            }

            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            if (this.Radius <= 0)
            {
                throw new ArgumentException("Circle's surface can not be calculated, because of invalid parameter");
            }

            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
