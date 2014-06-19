namespace Methods
{
    using System;
    using System.Linq;

    public struct Point
    {        
        public Point(double x, double y)
            : this()
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
        }

        public double CoordinateX { get; set; }

        public double CoordinateY { get; set; }
    }
}
