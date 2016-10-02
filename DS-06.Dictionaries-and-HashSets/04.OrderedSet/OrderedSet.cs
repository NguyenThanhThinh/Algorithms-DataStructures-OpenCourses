namespace _04.OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTree<T> root;

        public int Count { get; set; }

        public void Add(T value)
        {
            if (this.root == null)
            {
                this.root = new BinaryTree<T>(value);
                this.Count++;
            }
            else
            {
                if (this.root.AddChild(value))
                {
                    this.Count++;
                }
            }
        }

        public bool Remove(T value)
        {
            var currentNode = this.root.ContainsValue(value);
            if (currentNode == null)
            {
                return false;
            }

            if (currentNode.RightNode != null && currentNode.LeftNode != null)
            {
                var moveNode = currentNode.RightNode;
                while (moveNode.LeftNode != null)
                {
                    moveNode = moveNode.LeftNode;
                }

                moveNode.Parent.LeftNode = null;
                moveNode.LeftNode.Parent = moveNode;
                moveNode.RightNode = currentNode.RightNode;
                moveNode.RightNode.Parent = moveNode;

                if (currentNode.Parent == null)
                {
                    moveNode.Parent = null;
                    this.root = moveNode;
                }
                else
                {
                    if (currentNode.IsLeftChild())
                    {
                        currentNode.Parent.LeftNode = moveNode;
                    }
                    else
                    {
                        currentNode.Parent.RightNode = moveNode;
                    }

                    moveNode.Parent = currentNode.Parent;
                }
            }
            else if (currentNode.RightNode != null)
            {
                if (currentNode.IsLeftChild())
                {
                    currentNode.Parent.LeftNode = currentNode.RightNode;
                }
                else
                {
                    currentNode.Parent.RightNode = currentNode.RightNode;
                }

                currentNode.RightNode.Parent = currentNode.Parent;
            }
            else if (currentNode.LeftNode != null)
            {
                if (currentNode.IsLeftChild())
                {
                    currentNode.Parent.LeftNode = currentNode.LeftNode;
                }
                else
                {
                    currentNode.Parent.RightNode = currentNode.LeftNode;
                }

                currentNode.LeftNode.Parent = currentNode.Parent;
            }
            else
            {
                if (currentNode.IsLeftChild())
                {
                    currentNode.Parent.LeftNode = null;
                }
                else
                {
                    currentNode.Parent.RightNode = null;
                }
            }

            this.Count--;
            return true;
        }

        public bool Contains(T value) => this.root.ContainsValue(value) != null;

        public IEnumerator<T> GetEnumerator() => this.root.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void PrintBfs() => this.root.PrintEach();

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            var index = 0;
            foreach (var tree in this.root)
            {
                arr[index++] = tree;
            }
            return arr;
        }
    }
}
