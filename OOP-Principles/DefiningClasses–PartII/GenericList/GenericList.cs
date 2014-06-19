using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericList<T> where T : IComparable
    {
        //Keep the elements of the list in an array with fixed capacity 
        private T[] elementsArray;
        private int count = 0;
        private int initialCapacity;

        public GenericList(int capacity)
        {
            this.elementsArray = new T[capacity];
            this.initialCapacity = capacity;
        }

        //indexer 
        public T this[int index]
        {
            get { return elementsArray[index]; }
            set { this.elementsArray[index] = value; }
        }

        //methods
        public void AutoGrowArray()
        {
            // Implementing auto-grow as required.
            T[] bigger = new T[this.elementsArray.Length * 2];
            Array.Copy(elementsArray, 0, bigger, 0, elementsArray.Length);
            elementsArray = bigger;
        }

        public void AddElement(T element)
        {
            if (this.count >= this.elementsArray.Length)
            {
                AutoGrowArray();
                elementsArray[count] = element;
                count++;

                /* Implementing autogrow like a list, with one element at a time. This wil prevent unnecessary print of zeroes in method ToString();
                T[] bigger = new T[this.elementsArray.Length + 1];
                for (int i = 0; i < this.elementsArray.Length; i++)
                {
                    bigger[i] = elementsArray[i];
                }
                this.elementsArray = bigger;
                this.elementsArray[this.count] = element;
                count++; */

            }
            else
            {
                this.elementsArray[this.count] = element;
                this.count++;
            }
        }
        //finding element by its value 
        public int FindIndex(T valueOfElement)
            {
                int index = 0;
                for (int i = 0; i < this.elementsArray.Length; i++)
                {
                    if(this.elementsArray[i].Equals(valueOfElement))
                    {
                        index = i;
                        break;
                    }
                }
                return index;
            }

        //clearing the list
        public void Clear()
        {
            T[] cleared = new T[this.initialCapacity];
            this.elementsArray = cleared;
        }

        public int GetLenght()
        {
            return this.elementsArray.Length;
        }

        //inserting element at given position
        public void InsertElement(int index, T element)
        {
            if (index < this.elementsArray.Length && index >= 0)
            {
                // Implementing autogrow as required.
                //T[] array = new T[this.mainArray.Length * 2];

                // Implementing autogrow like a list, with one element at a time. This wil prevent unnecessary print of zeroes in method ToString()
                T[] array = new T[this.elementsArray.Length + 1];

                for (int i = 0; i < index; i++)
                {
                    array[i] = elementsArray[i];
                }

                array[index] = element;

                for (int i = index + 1, oldIndex = index; i < this.elementsArray.Length + 1; i++, oldIndex++)
                {
                    array[i] = this.elementsArray[oldIndex];
                }

                this.elementsArray = array;
            }

            else if (index == this.elementsArray.Length)
            {
                // Implementing autogrow as required.
                //T[] array = new T[this.mainArray.Length * 2];

                // Implementing autogrow like a list, with one element at a time. This wil prevent unnecessary print of zeroes in method ToString()
                T[] array = new T[this.elementsArray.Length + 1];

                for (int i = 0; i < index; i++)
                {
                    array[i] = elementsArray[i];
                }

                array[index] = element;
                this.elementsArray = array;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The index given is outside the array");
            }
        }

        //removing element by index
        public void RemoveElementAt(int index)
        {
            if (index < this.elementsArray.Length && index >= 0)
            {
                T[] array = new T[this.elementsArray.Length - 1];

                for (int i = 0; i < index; i++)
                {
                    array[i] = this.elementsArray[i];
                }

                for (int i = index; i < this.elementsArray.Length - 1; i++)
                {
                    array[i] = this.elementsArray[i + 1];
                }
                this.elementsArray = array;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The index given is outside the array");
            }
        }

        public T Min()
        {
            dynamic leastElement = int.MaxValue;
            for (int i = 0; i < this.elementsArray.Length; i++)
            {
                if (this.elementsArray[i] < leastElement)
                {
                    leastElement = this.elementsArray[i];
                }
            }
            return leastElement;
        }

        public T Max()
        {
            dynamic biggestElement = int.MinValue;
            for (int i = 0; i < this.elementsArray.Length; i++)
            {
                if (this.elementsArray[i] > biggestElement)
                {
                    biggestElement = this.elementsArray[i];
                }
            }
            return biggestElement;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this.elementsArray)
            {
                sb.AppendFormat("{0}", item);
            }
            return sb.ToString().TrimEnd();
        }
    }
}

	


			 
			

			 
			
			          

			
			



       


			

  