namespace _01.DataStructuresAlgorithmsComplexity
{
    using System;

    public class StupidList<T>
    {
        private T[] arr = new T[0];

        // Total Complexity: O(1)
        public T First
        {
            get
            {
                // Complexity: O(1)
                return this.arr[0];
            }
        }

        // Total Complexity: O(1)
        public T Last
        {
            get
            {
                // Complexity: O(1)
                return this.arr[this.arr.Length - 1];
            }
        }

        // Total Complexity: O(1)
        public int Length
        {
            get
            {
                // Complexity: O(1)
                return this.arr.Length;
            }
        }

        // Total Complexity: O(1)
        public T this[int index]
        {
            get
            {
                // Complexity: O(1)
                return this.arr[index];
            }
        }

        // Total Complexity: O(n)
        public void Add(T item)
        {
            // Complexity: O(n)
            var newArr = new T[this.arr.Length + 1];

            // Complexity: O(n)
            Array.Copy(this.arr, newArr, this.arr.Length);

            // Complexity: O(1)
            newArr[newArr.Length - 1] = item;

            // Complexity: O(1)
            this.arr = newArr;
        }

        // Total Complexity: O(n)
        public T Remove(int index)
        {
            // Complexity: O(1)
            T result = this.arr[index];

            // Complexity: O(n)
            var newArr = new T[this.arr.Length - 1];

            // Complexity: O(n)
            Array.Copy(this.arr, newArr, index);

            // Complexity: O(n)
            Array.Copy(this.arr, index + 1, newArr, index, this.arr.Length - index - 1);

            // Complexity: O(1)
            this.arr = newArr;
            return result;
        }

        // Total Complexity: O(1)
        public T RemoveFirst()
        {
            // Complexity: O(1)
            return this.Remove(0);
        }

        // Total Complexity: O(1)
        public T RemoveLast()
        {
            // Complexity: O(1)
            return this.Remove(this.Length - 1);
        }
    }
}