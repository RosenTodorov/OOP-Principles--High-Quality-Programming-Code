using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace _4.BinarySearchTree
{
        public class BinarySearchTree<T> : ICloneable, IEnumerable<T> where T : IComparable<T>
        {
            private BinaryTreeNode<T> root;

            public BinarySearchTree()
            {
                this.root = null;
            }

            // insert functionality    
            public void Insert(T value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot insert null value");
                }
                this.root = Insert(value, null, root);
            }

            private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    node = new BinaryTreeNode<T>(value);
                    node.parent = parentNode;
                }
                else
                {
                    int compareTo = value.CompareTo(node.value);
                    if (compareTo < 0)
                    {
                        node.leftChild = Insert(value, node, node.leftChild);
                    }
                    else if (compareTo > 0)
                    {
                        node.rightChild = Insert(value, node, node.rightChild);
                    }
                }
                return node;
            }

            // inner class search, which helps the remove functionality                 
            private BinaryTreeNode<T> Find(T value)
            {
                BinaryTreeNode<T> node = this.root;
                while (node != null)
                {
                    int compareTo = value.CompareTo(node.value);
                    if (compareTo < 0)
                    {
                        node = node.leftChild;
                    }
                    else if (compareTo > 0)
                    {
                        node = node.rightChild;
                    }
                    else
                    {
                        break;
                    }
                }
                return node;
            }

            // remove operation        
            public void Remove(T value)
            {
                BinaryTreeNode<T> nodeToDelete = Find(value);
                if (nodeToDelete == null)
                {
                    return;
                }
                Remove(nodeToDelete);
            }
            private void Remove(BinaryTreeNode<T> node)
            {
                if (node.leftChild == null && node.rightChild == null)
                {
                    BinaryTreeNode<T> replacement = node.rightChild;
                    while (replacement.leftChild != null)
                    {
                        replacement = replacement.leftChild;
                    }
                    node.value = replacement.value;
                    node = replacement;
                }

                BinaryTreeNode<T> theChild = node.leftChild != null ? node.leftChild : node.rightChild;

                // if the element to be deleted has only one child     
                if (theChild != null)
                {
                    theChild.parent = node.parent;

                    // the element is the root         
                    if (node.parent == null)
                    {
                        root = theChild;
                    }
                    else
                    {
                        // replace the element with its child subtree 
                        if (node.parent.leftChild == node)
                        {
                            node.parent.leftChild = theChild;
                        }
                        else
                        {
                            node.parent.rightChild = theChild;
                        }
                    }
                }
                else
                {

                    // the element is the root      
                    if (node.parent == null)
                    {
                        root = null;
                    }
                    else
                    {
                        // the element is a leaf       
                        if (node.parent.leftChild == null)
                        {
                            node.parent.leftChild = null;
                        }
                        else
                        {
                            node.parent.rightChild = null;
                        }
                    }
                }
            }

            // implementing the IEnumerable interface methods      
            private IEnumerable<T> Traverse(BinaryTreeNode<T> root)
            {
                if (root != null)
                {
                    foreach (var item in Traverse(root.leftChild))
                    {
                        yield return item;
                    }
                    yield return root.value;

                    foreach (var item in Traverse(root.rightChild))
                    {
                        yield return item;
                    }
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                return Traverse(root).GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            // implementing the ICloneable interface methods     
            public object Clone()
            {
                BinarySearchTree<T> newTree = new BinarySearchTree<T>();
                foreach (var item in this)
                {
                    newTree.Insert(item);
                }
                return newTree;
            }
            public override string ToString()
            {
                return String.Join<T>(" ", this);
            }
            public override int GetHashCode()
            {
                int hash = 17;
                unchecked
                {
                    foreach (var item in this)
                    {
                        hash = 23 * hash + item.GetHashCode();
                    }
                }
                return hash;
            }
            public override bool Equals(object obj)
            {
                IEnumerator<T> firstTree = this.GetEnumerator();
                IEnumerator<T> secondTree = (obj as BinarySearchTree<T>).GetEnumerator();
                while (firstTree.MoveNext() && secondTree.MoveNext())
                {
                    if (!firstTree.Current.Equals(secondTree.Current))
                    {
                        return false;
                    }
                }
                return true;
            }

            // overridib bool operators      
            public static bool operator ==(BinarySearchTree<T> first, BinarySearchTree<T> second)
            {
                return BinarySearchTree<T>.Equals(first, second);
            }
            public static bool operator !=(BinarySearchTree<T> first, BinarySearchTree<T> second)
            {
                return !BinarySearchTree<T>.Equals(first, second);
            }
        }
    }
