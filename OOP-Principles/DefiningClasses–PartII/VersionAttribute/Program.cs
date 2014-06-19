using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace VersionAttribute
{
    class Program 
    { 
        static void Main() 
        { 
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; 
            MotorSampleClass newCar = new MotorSampleClass(SampleMotorsEnumMaker.Ducati, SampleMotorsEnumColor.Red, 75); 
            Type type = typeof(MotorSampleClass);
 
            object[] allAttributes = type.GetCustomAttributes(false); foreach (VersionAttribute attr in allAttributes) 
            { 
                Console.WriteLine("Current version is: {0} ", attr.Version); 
            } 
        } 
    }
}