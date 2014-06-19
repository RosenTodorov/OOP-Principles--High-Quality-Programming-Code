using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Timer
    {
        public void PrintRegards(string regards)
        {
            Console.WriteLine("Said: {0} at {1}", regards, DateTime.Now);
        }
    }
}