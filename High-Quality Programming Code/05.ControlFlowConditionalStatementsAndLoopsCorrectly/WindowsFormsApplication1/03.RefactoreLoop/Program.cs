namespace RefactoreLoop
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] integers = new int[] { 1, 2, 4, 6, 10, 23, 345, 7, 8, 10 };
            int expectedValue = 10;

            for (int index = 0; index < 100; index++)
			{
                if (index % 10 == 0)
                {
                   Console.WriteLine(integers[index]);
                    if (integers[index] == expectedValue)
                    {
                       Console.WriteLine("Value Found");
                        break;
                    }
                }
			}
            // More code here            
        }
    }
}