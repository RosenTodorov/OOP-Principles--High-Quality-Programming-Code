namespace RefactoreStatisticsMethod
{
    using System;
    using System.Linq;

    public class Prigram
    {
        public static void Main(string[] args)
        {
            double[] randomDigits = new double[] { 3.5, 2.0, 5.7, 1.2 };
            int randomDigitsCount = randomDigits.Length;
            PrintStatistics(randomDigits, randomDigitsCount);
        }

        public static void PrintStatistics(double[] inputArray, int arrayLength)
        {
            double maximumValue = int.MinValue;

            for (int index = 0; index < arrayLength; index++)
            {
               if(inputArray[index] > maximumValue)
               {
                   maximumValue = inputArray[index];
               }
            }

            PrintMax(maximumValue);
            maximumValue = 0;

            double minimumValue = int.MaxValue;

            for (int index = 0; index < arrayLength; index++)
            {
               if(inputArray[index] < minimumValue)
               {
                   minimumValue = inputArray[index];
               }
            }

            PrintMin(maximumValue);

            double currnetSumOfValues = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                currnetSumOfValues += inputArray[i];
            }

            PrintAvg(currnetSumOfValues / arrayLength);
        }
			 
        private static void PrintMax(double maximumValue)
        {
            Console.WriteLine("Maximum Value: " + maximumValue);
        }

        private static void PrintMin(double maximumValue)
        {
            Console.WriteLine("Maximum Value: " + maximumValue);
        }

        private static void PrintAvg(double averageValue)
        {
            Console.WriteLine("Average Value: " + averageValue);
        }
    }
}