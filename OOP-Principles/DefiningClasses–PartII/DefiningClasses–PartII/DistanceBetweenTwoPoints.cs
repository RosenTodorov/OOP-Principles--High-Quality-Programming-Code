using Euclidian3DSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuclidianSpacePoint
{
    public static class DistanceBetweenTwoPoints
    {
        public static double CalculateDistanceBetweenTwoPoints(Point3D a, Point3D b)
        {
            double distance = 0;
            distance = Math.Sqrt(Math.Pow(a.coordinateX - b.coordinateX, 2) + Math.Pow(a.coordinateY - b.coordinateY, 2) + Math.Pow(a.coordinateZ - b.coordinateZ, 2));

            return distance;
        }
    }
}
 