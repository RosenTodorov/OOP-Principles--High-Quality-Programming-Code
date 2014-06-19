using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InvalidRangeException
{
    class InvalidRangeException<T> : Exception
    {
        //It should hold error message and a range definition [start … end].

        private const string message = "Not in the range!"; 

        public InvalidRangeException(T start, T end, Exception innerException = null) : base(message, innerException)
        { 
           this.start = start; 
           this.end = end; 
        } 
       
        public T start { get; set; }       
        public T end { get; set; }
    }
}

