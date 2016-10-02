namespace _06.ReversedList
{
    public interface IReversedList<T>
    {
        int Capacity { get; }

        int Size { get; }

        T this[int index] { get; set; }

        void Add(T item);

        void RemoveAt(int index);

        void Clear();
    }
}