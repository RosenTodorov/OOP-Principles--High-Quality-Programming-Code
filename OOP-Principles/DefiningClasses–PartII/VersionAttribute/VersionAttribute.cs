using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionAttribute
{
    [System.AttributeUsage(System.AttributeTargets.Enum | System.AttributeTargets.Class |
        System.AttributeTargets.Struct | System.AttributeTargets.Interface | System.AttributeTargets.Method)]

    public class VersionAttribute : System.Attribute
    {
        private double version;
        public VersionAttribute(double version)
        {
            this.version = version;
        }
        public double Version
        {
            get { return this.version; }
        }
    }
}
    
        


