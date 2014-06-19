namespace Abstraction
{
    using System;
    public class FiguresExample
    {
        private static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine("I am a circle. " + circle.ToString());

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. " + rect.ToString());
        }
    }
}
