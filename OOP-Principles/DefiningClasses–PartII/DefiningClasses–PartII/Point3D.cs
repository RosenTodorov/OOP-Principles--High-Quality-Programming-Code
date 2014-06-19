using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses_PartII;


namespace Euclidian3DSpace
{
    public struct Point3D
    {
        //Add a private static read-only field 
        private static readonly Point3D PointZero = new Point3D(0, 0, 0);

        public int coordinateX { get; set; }
        public int coordinateY { get; set; }
        public int coordinateZ { get; set; }

        public Point3D(int CoordianteX, int CoordianteY, int CoordinateZ)
            : this()
        {
            this.coordinateX = CoordianteX;
            this.coordinateY = CoordianteY;
            this.coordinateZ = CoordinateZ;
        }
        
        //Add a static property to return the point O
        public static Point3D ZeroPoint
        {
            get { return PointZero; }
        }

        //Implement the ToString() to enable printing a 3D point.
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" Euclidian D-coordinates ");
            sb.AppendFormat("X coordinate = {0}; \n", this.coordinateX);
            sb.AppendFormat("Y coordinate = {0}; \n", this.coordinateY);
            sb.AppendFormat("Z coordinate = {0}; \n", this.coordinateZ);

            return sb.ToString();
        }
    }
}

        



    





                 
    

    
    

