using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class Program
    {
        static void Main()
        {
            Matrix<int> m1 = new Matrix<int>(3, 4);
            m1[1, 2] = 40;
            Matrix<int> m2 = new Matrix<int>(3, 4);
            m2[1, 2] = 20;

            var result = m1 + m2;

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Cols; j++)
                {
                    Console.Write("{0,3} ", result[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}


			
			 
	