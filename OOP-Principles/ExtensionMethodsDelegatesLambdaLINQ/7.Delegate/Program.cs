using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// 7. Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace Delegate
{
    class Program
    {
        public delegate void Regard(string regards);

        static void Main()
        {
            Console.WriteLine("Input t (seconds): ");
            int t = int.Parse(Console.ReadLine());
            Timer timer = new Timer();

            Regard regards = new Regard(timer.PrintRegards);

            while (true)
            {
                regards("Yours Sincerely");
                Thread.Sleep(t * 1000);
            }
        }
    }
}
                    


