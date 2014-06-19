using Euclidian3DSpace;
using EuclidianSpacePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses_PartII
{
    class Program
    {
        static void Main()
        {
            // creating a new point and printing its coordinates
            Point3D firstPoint = new Point3D(3, 4, 5);
            Point3D secondPoint = new Point3D(1, 3, 6);
            Console.WriteLine(firstPoint.ToString());
            Console.WriteLine(secondPoint.ToString());

            // printing the static zero point's coordinates
            Console.WriteLine(Point3D.ZeroPoint.ToString());

            // Euclidian distance
            Console.WriteLine(DistanceBetweenTwoPoints.CalculateDistanceBetweenTwoPoints(firstPoint, secondPoint));

            // creating new sequence of points; adding the created points to the sequence; saving the sequence to a file;
            // clearing  the sequence; reading the file and filling the initiated sequence again, after which printing their coordinates
            Path points = new Path();
            points.AddPointToSequence(firstPoint);
            points.AddPointToSequence(secondPoint);
            points.AddPointToSequence(Point3D.ZeroPoint);
            PathStorage.SavePathFromATextFile(points);
            points.ClearSequence();

            points = PathStorage.LoadLastPathFromFile();
            foreach (var point in points.SequenceOfPoints)
            {
                Console.WriteLine(point.ToString());
            }
        }
    }
}