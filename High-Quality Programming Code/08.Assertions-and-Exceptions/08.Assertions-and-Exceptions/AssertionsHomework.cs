using System;
using System.Linq;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The array, trying to use is null");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        bool arraySortCondition = CheckForProperSorting(arr);
        Debug.Assert(arraySortCondition, "Array is not properly sorted");
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        bool arraySortCondition = CheckForProperSorting(arr);
        Debug.Assert(arraySortCondition, "Array is not properly sorted");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    private static bool CheckForProperSorting<T>(T[] arr) where T : IComparable<T>
    {
        bool isPropSorted = true;

        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i - 1].CompareTo(arr[i]) > 0)
            {
                isPropSorted = false;
            }
        }

        return isPropSorted;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The array, trying to use is null");
        Debug.Assert(startIndex >= 0, "The start index can not be negative integer");
        Debug.Assert(endIndex <= arr.Length - 1, "End index can not be greater than the array's length");
        Debug.Assert(startIndex < endIndex, "End index can not be smaller than the starting index");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }
        return minElementIndex;
    }

    private static void Swap<T>(ref T firstArgument, ref T secondArgument)
    {
        Debug.Assert(firstArgument != null, "Argument can't be null");
        Debug.Assert(secondArgument != null, "Argument can't be null");

        T oldValueOfFirstArgument = firstArgument;
        firstArgument = secondArgument;
        secondArgument = oldValueOfFirstArgument;
    }
}

