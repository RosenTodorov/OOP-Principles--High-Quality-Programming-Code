namespace Methods
{
    using System;
    public class Methods
    {
        private static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("The length of each side should be bigger than zero");
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            return triangleArea;
        }

        private static string ValueOfNumberToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Number isn't recognized!");
            }
        }

        private static int FindElementWithMaximumValue(params int[] elements)
        {
            if (elements == null)
            {
                throw new NullReferenceException("The array used with elements can not be null");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("The array used with elements is empty");
            }

            int maximumValue = elements[0];
            for (int index = 1; index < elements.Length; index++)
            {
                if (elements[index] > maximumValue)
                {
                    maximumValue = elements[index];
                }
            }
            return maximumValue;
        }

        private static void PrintElementFormatedAsNumber(object element, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", element);
            }

            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", element);
            }

            else if (format == "r")
            {
                Console.WriteLine("{0,8}", element);
            }

            else
            {
                throw new ArgumentException("The format is not recognized");
            }
        }

        private static bool CheckIfHorizontal(Point first, Point second)
        {
            bool isHorizontal = first.CoordinateY == second.CoordinateY;

            return isHorizontal;
        }

        private static bool CheckIfVertical(Point first, Point second)
        {
            bool isVertical = first.CoordinateX == second.CoordinateX;

            return isVertical;
        }
   
        private static double CalcDistance(Point first, Point second)
        {
            double poweredX = Math.Pow(second.CoordinateX - first.CoordinateX, 2);
            double poweredY = Math.Pow(second.CoordinateY - second.CoordinateY, 2);
            double distance = Math.Sqrt(poweredX + poweredY);

            return distance;
        }

        private static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ValueOfNumberToString(5));

            Console.WriteLine(FindElementWithMaximumValue(5, -1, 3, 2, 14, 2, 3));

            PrintElementFormatedAsNumber(1.3, "f");
            PrintElementFormatedAsNumber(0.75, "%");
            PrintElementFormatedAsNumber(2.30, "r");

            Point first = new Point(3, -1);
            Point second = new Point(3, 2.5);

            Console.WriteLine(CalcDistance(first, second));
            Console.WriteLine("Horizontal? " + CheckIfHorizontal(first, second));
            Console.WriteLine("Vertical? " + CheckIfVertical(first, second));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia";
            peter.BirthDate = new DateTime(1992, 03, 17);

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results";
            stella.BirthDate = new DateTime(1993, 11, 03);

            Console.WriteLine(
               "{0} older than {1} -> {2}",
                peter.FirstName, 
                stella.FirstName, 
                peter.IsOlderThan(stella));
        }
    }
}











