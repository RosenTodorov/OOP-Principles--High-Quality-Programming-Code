using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VersionAttribute
{
    [VersionAttribute(2.11)]
    class MotorSampleClass 
    { 
        private SampleMotorsEnumColor color;
        private SampleMotorsEnumMaker maker;
        private int horsePower;

        public MotorSampleClass(SampleMotorsEnumMaker maker, SampleMotorsEnumColor color, int horsePower) 
        { 
            this.maker = maker; 
            this.color = color; 
            this.horsePower = horsePower; 
        }

        public SampleMotorsEnumColor Color
        { 
            get { return this.color; } 
            set { this.color = value; } 
        }

        public SampleMotorsEnumMaker Maker 
        { 
            get { return this.maker; } 
            set { this.maker = value; } 
        } 
        
        public int HorsePower 
        { 
            get { return this.horsePower; } 
            set { this.horsePower = value; }
        }
    }
}