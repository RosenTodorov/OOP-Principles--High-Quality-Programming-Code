using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 5. Define a class BitArray64 to hold 64 bit values inside an ulong value.
   Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.*/

namespace _3.BitArray64
{
    class Program
    {
        static void Main()
        {
            BitArray64 bits = new BitArray64(ulong.Parse(Console.ReadLine()));
            var bitz = bits.Bits;
            Console.WriteLine(bits[4]);

            foreach (var bit in bitz)
            {
                Console.Write(bit);
            }
            Console.WriteLine();

            BitArray64 bitss = new BitArray64(ulong.Parse(Console.ReadLine()));

            Console.WriteLine(bits.Equals(bitss));
            Console.WriteLine(bitss.GetHashCode());
            Console.WriteLine(bits.GetHashCode());
        }
    }
}
                        
