namespace _05.Sorting
{
    using System;

    public class Permutation<T> where T : IComparable<T>
    {
        public Permutation(T[] sequence, int order = 0)
        {
            this.Sequence = sequence;
            this.Order = order;
        }

        public T[] Sequence { get; private set; }

        public int Order { get; private set; }

        public bool IsSorted()
        {
            for (int i = 0; i < this.Sequence.Length - 1; i++)
            {
                if (this.Sequence[i].CompareTo(this.Sequence[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return string.Join(string.Empty, this.Sequence);
        }
    }
}