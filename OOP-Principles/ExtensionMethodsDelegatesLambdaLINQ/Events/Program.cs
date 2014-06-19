using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/* 8. Read in MSDN about the keyword event in C# and how to publish events. 
  Re-implement the above using .NET events and following the best practices. */

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input seconds between publishing: ");
            int t = int.Parse(Console.ReadLine());
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber("sub", pub);

            while (true)
            {
                pub.DoSomething();
                Thread.Sleep(t * 1000);
            }
        }
    }
}