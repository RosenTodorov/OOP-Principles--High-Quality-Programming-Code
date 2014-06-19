using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;

/* 5. Define a class BitArray64 to hold 64 bit values inside an ulong value.
   Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.*/

namespace _3.BitArray64
{
   class BitArray64 : IEnumerable<int>   
   {       
       private readonly ulong number;    

       // constructor     
       public BitArray64(ulong number = 0)   
       {           
           this.number = number;  
       }      

       // indexer    
       public int this[int index]   
       {         
           get        
           {          
               if (index < 0 || index > 63)    
               {              
                   throw new ArgumentOutOfRangeException("Index out of range.");        
               }               
               else      
               {              
                   int[] bits = this.GetBits();          
                   return bits[63 - index]; // intentionally returning the [63-index] bit, so the original bit counting could be kept           
               }         
           }     
       }      

       // int array property, representing bits     
       public int[] Bits       
       {          
           get { return this.GetBits(); }    
       }      

       // Method for filling the 64 ellement array with 0 or 1, according to number       
       private int[] GetBits()      
       {           
           ulong num = this.number;   
           int bitPosition = 63;     
           int[] bits = new int[64];   
           while (num != 0)        
           {               
               bits[bitPosition] = (int)(num % 2);   
               num /= 2;              
               bitPosition--;         
           }         
           while (bitPosition >= 0)     
           {              
               bits[bitPosition] = 0;    
               bitPosition--;          
           }          
           return bits;   
       }      

       // implementing the IEnumerable<int>      
       public IEnumerator<int> GetEnumerator()     
       {           
           int[] bits = this.GetBits();         
           for (int i = 0; i < bits.Length; i++)   
           {              
               yield return bits[i];      
           }      
       }       
       IEnumerator IEnumerable.GetEnumerator()     
       {        
           return this.GetEnumerator();  
       }       

       // overriding methods      
       // Equals      
       public override bool Equals(object obj)    
       {         
           BitArray64 tempNumber = obj as BitArray64;        
           if (tempNumber.number == this.number)    
           {              
               return true;       
           }           
           return false;       
       }     
       
       // Get hashcode  
       public override int GetHashCode()  
       {       
           int[] bitz = this.GetBits();    
           //byte[] bits = new byte[64];     
           //for (int i = 0; i < 64; i++)       
           //{ 
           //    bits[i] = (byte)bitz[i];   
           //}        
           //return BitConverter.ToInt32(new MD5CryptoServiceProvider().ComputeHash(bits), 0);    
           return this.number.GetHashCode();     
       }       
       //overriding operators      

       public static bool operator ==(BitArray64 first, BitArray64 second)      
       {           
           return BitArray64.Equals(first, second);  
       }      
       public static bool operator !=(BitArray64 first, BitArray64 second)   
       {         
           return !BitArray64.Equals(first, second);     
       }  
   }
}

/*
         //second way
        public class BitArray64 : IEnumerable<int>    
        {       
            private int[] bitArray = new int[64];    
            private ulong number;     
            public BitArray64(ulong number)      
            {            
                this.number = number;           
                // fills array with bits of the number        
                for (int i = 0; i < 64 ; i++)      
                {               
                    bitArray[i] = (int)(number % 2);     
                    number /= 2;          
                }       
            }      

            // PROPERTIES         
            public ulong Number    
            {            
                get { return this.number; }    
            } 
     
            // METHODS    
            // implement foreach    
            IEnumerator IEnumerable.GetEnumerator()  
            {       
                // Call the generic version of the method       
                return this.GetEnumerator(); 
            }       
            public IEnumerator<int> GetEnumerator()  
            {         
                for (int i = 63; i >= 0; i--)  
                {          
                    yield return this.bitArray[i];       
                }       
            }      
            public override bool Equals(object obj)    
            {           
                BitArray64 bitArray = obj as BitArray64;    
                if ((object)bitArray == null)     
                {                
                    return false;     
                }        
                if (Object.Equals(this.number, bitArray.number))  
                {         
                    return true;     
                }            
                return false;     
            }        
            public static bool operator ==(BitArray64 firstNumber, BitArray64 secondNumber)   
            {           
                return BitArray64.Equals(firstNumber, secondNumber);  
            }       
            public static bool operator !=(BitArray64 firstNumber,       
                BitArray64 secondNumber)    
            {       
                return !(BitArray64.Equals(firstNumber, secondNumber));      
            }       
            public int this[int key]     
            {          
                get { return this.bitArray[key]; }       
                set           
                {            
                    if (value == 1 || value == 0)    
                    {                 
                        this.bitArray[key] = value;  
                        ChangeNumber();         
                    }              
                    else          
                    {                
                        throw new ArgumentException("You can insert only bits 0 and 1.");    
                    }         
                }       
            }     
            public override int GetHashCode()    
            {        
                return this.number.GetHashCode() ^ this.bitArray.GetHashCode();    
            }        
            // this method change number after we change somewhere some bit   
            private void ChangeNumber()     
            {          
                this.number = 0;   
                // calculate new number     
                for (int i = 0; i < 64; i++)    
                {              
                    this.number += (ulong)(this.bitArray[i] << i);
                    // with this shift I make pow      
                }        
            }   
        }
*/


























