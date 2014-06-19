using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 3. Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. 
 * It should hold error message and a range definition [start … end]. Write a sample application that demonstrates the 
 * InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] 
 * and dates in the range [1.1.1980 … 31.12.2013].*/

namespace _3.InvalidRangeException
{
    class Program
    {
        static void Main()
        {
            try       
            {      
                int start = 1;     
                int end = 100;       
                for (int i = 100; i < 102; i++)     
                {            
                    if (i >= 1 && i <= 100)         
                    {                   
                        Console.WriteLine(i);   
                    }                   
                    else                 
                    {                 
                        throw new InvalidRangeException<int>(start, end);  
                    }          
                }          
            }         
  
            catch (InvalidRangeException<int> ire)     
            {               
                Console.WriteLine(ire.Message);     
                Console.WriteLine("Start: {0} End: {1}",ire.start, ire.end);    
            }           
            Console.WriteLine();       
    
            try        
            {          
                DateTime start = new DateTime(1980, 1, 1);    
                DateTime end = new DateTime(2013, 12, 31);     
                DateTime date = new DateTime(2015, 2, 12);        
  
                if (date >= start && date <= end)          
                {                  
                    Console.WriteLine(date);   
                }              
                else         
                {              
                    throw new InvalidRangeException<DateTime>(start, end);     
                }                   
            }            
            catch (InvalidRangeException<DateTime> ire)   
            {               
                Console.WriteLine(ire.Message);          
                Console.WriteLine("Start: {0} End: {1}", ire.start, ire.end);         
            }      
        }  
    }
}

