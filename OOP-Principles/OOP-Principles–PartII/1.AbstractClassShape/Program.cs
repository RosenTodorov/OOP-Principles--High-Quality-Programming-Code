using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/* 1. Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. 
 * Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of 
 * the figure (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable 
 * constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() method. Write a 
 * program that tests the behavior of the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array.*/

namespace AbstractClassShape
{
    class Program
    {
        static void Main()
        {
            //tests the behavior of the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Shape[] shapes = 
            {
                new Triangle(2d, 4d),
                new Rectangle(5d, 9d), 
                new Circle(6d)
            };

            foreach (var shape in shapes)
            {

                Console.WriteLine(shape.CalculateSurface());
                Console.WriteLine();
            }
        }
    }
}

                
