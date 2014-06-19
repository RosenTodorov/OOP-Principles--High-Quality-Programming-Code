using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 6. Define the data structure binary search tree with operations 
 * for "adding new element", "searching element" and "deleting elements". 
 * It is not necessary to keep the tree balanced. Implement the standard 
 * methods from System.Object – ToString(), Equals(…), GetHashCode() and 
 * the operators for comparison  == and !=. Add and implement the ICloneable 
 * interface for deep copy of the tree. Remark: Use two types – structure 
 * BinarySearchTree (for the tree) and class TreeNode (for the tree elements). Implement IEnumerable<T> to traverse the tree.*/

namespace _4.BinarySearchTree
{
    class Program
    {
        static void Main()
        {
            BinarySearchTree<double> tree = new BinarySearchTree<double>(); 
            // could work with int and other types, which can be compared           
            //Random rand = new Random();          
            //for (int i = 1; i <= 50; i++)         
            //{           
            //   tree.Insert(rand.Next(1,101));        
            //}           
            // every node is being checked, reaching the leafes, so the elements are sorted     
            tree.Insert(50.45);       
            tree.Insert(0);        
            tree.Insert(5);        
            tree.Insert(20);        
            tree.Insert(46);       
            tree.Insert(26);        
            tree.Insert(91.56); 
        
            Console.WriteLine(tree.ToString());  
        }   
    }
}