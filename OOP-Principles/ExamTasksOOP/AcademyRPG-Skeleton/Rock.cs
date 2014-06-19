using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        public Rock(int hitPoints, Point position)
            : base(position)
        {
            this.HitPoints = hitPoints;
        }

        public int Quantity
        {
            get { return HitPoints/2; }
        }

        public ResourceType Type
        {
            get { return ResourceType.Stone; }
        }
    }
}
