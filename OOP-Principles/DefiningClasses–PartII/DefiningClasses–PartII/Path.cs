using Euclidian3DSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses_PartII
{
    public class Path
    {
        public readonly List<Point3D> SequenceOfPoints = new List<Point3D>();

        public void AddPointToSequence(Point3D point)
        {
            this.SequenceOfPoints.Add(point);
        }

        public void ClearSequence()
        {
            this.SequenceOfPoints.Clear();
        }

        public void Remove(Point3D point)
        {
            this.SequenceOfPoints.Remove(point);
        }
    }
}
