using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableExtensions
{
    public static class ExtendIEnumerable
    {
        public static T Sum<T>(this IEnumerable<T> element) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T> // constrain to work only with digits
        {
            dynamic result = 0;

            foreach (var item in element)
            {
                result += item;
            }

            return result;
        }

        public static T Product<T>(this IEnumerable<T> element) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = 1;
            foreach (var item in element)
            {
                result *= item;
            }
            return result;
        }

        public static T Min<T>(this IEnumerable<T> element) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = int.MaxValue;
            foreach (var item in element)
            {
                if (item < result)
                {
                    result = item;
                }
            }
            return result;
        }

        public static T Max<T>(this IEnumerable<T> element) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = int.MinValue;
            foreach (var item in element)
            {
                if (item > result)
                {
                    result = item;
                }
            }
            return result;
        }

        public static T Average<T>(this IEnumerable<T> element) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic result = element.Sum() / ((dynamic)element.Count());
            return result;
        }
    }
}
                
	
	