namespace Abstraction
{
    using System;
    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle's width should be bigger than 0");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle's hight should be bigger than 0");
                }

                this.height = value;
            }
        }
       

        public override double CalcPerimeter()
        {
            if (this.Width <= 0 || this.Height <= 0)
            {
                throw new ArgumentException("Calculation of perimeter can not be done, because of invalid perimeters");
            }
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            if (this.Width <= 0 || this.Height <= 0)
            {
                throw new ArgumentException("Calculation of surface can not be done, because of invalid perimeters");
            }

            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
