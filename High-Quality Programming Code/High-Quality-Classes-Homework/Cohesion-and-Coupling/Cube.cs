﻿namespace CohesionAndCoupling
{
    using System;
    public class Cube
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = GeometricalUtilities.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = GeometricalUtilities.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = GeometricalUtilities.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = GeometricalUtilities.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}
