using System;

namespace Library
{
    public class Stack<T>
    {
        public event StackHandler StackOverflow;
        public int Count { get; private set; }
        public Stack(int stackSize)
        {
            if (stackSize <= 0)
            {
                throw new ArgumentException("The stack size must be greater than zero");
            }
            size = stackSize;
            elements = new T[size];
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }
        public void Append(T element)
        {
            if (Count == size)
            {
                if (StackOverflow != null)
                {
                    StackEventArgs args = new StackEventArgs(size);
                    StackOverflow(this, args);
                }
            }
            else elements[Count++] = element;
        }
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T element = elements[--Count];
            elements[Count] = default;
            return element;
        }
        private T[] elements;
        private int size;
    }
}
