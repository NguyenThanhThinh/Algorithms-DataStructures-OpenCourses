namespace _05.LinkedStack
{
    public class LinkedStackNode<T>
    {
        public LinkedStackNode(T value, LinkedStackNode<T> nextNode = null)
        {
            this.Value = value;
        }

        public LinkedStackNode<T> NextNode { get; set; }

        public T Value { get; private set; }
    }
}