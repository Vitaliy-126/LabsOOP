using System;

namespace DataStructures
{
    public class SinglyLinkedList
    {
        public Node First { get; private set; }
        public Node Last { get; private set; }
        public int Size { get; private set; }
        public void Add(short value)
        {
            if (First != null)
            {
                Node node = new Node(value);
                node.Next = First;
                First = node;
                Size++;
            }
            else
            {
                First = Last = new Node(value);
                Size = 1;
            }
        }
        public int QuantityMultiplesOfThree()
        {
            int counter = 0;
            Node currentNode = First;
            while (currentNode != null)
            {
                if (currentNode.Value % 3 == 0)
                {
                    counter++;
                }
                currentNode = currentNode.Next;
            }
            return counter;
        }
        public void RemoveLargeForAverage()
        {
            double mean = 0;
            Node currentNode = First;
            while (currentNode != null)
            {
                mean += currentNode.Value;
                currentNode = currentNode.Next;
            }
            mean /= Size;
            Node prevNode = null;
            currentNode = First;
            while (currentNode != null)
            {
                if (currentNode.Value > mean)
                {
                    if (prevNode == null)
                    {
                        First = currentNode.Next;
                        Size--;
                    }
                    else
                    {
                        prevNode.Next = currentNode.Next;
                        Size--;
                    }
                }
                else
                {
                    prevNode = currentNode;
                }
                currentNode = currentNode.Next;
            }
            Last = prevNode;
        }
        public short this[int index]
        {
            get
            {
                if (index < 0 || index >= Size)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                if (Size == 0)
                {
                    throw new InvalidOperationException("The list is empty");
                }
                int counter = 0;
                short value = default;
                bool find = false;
                Node currentNode = First;
                while (currentNode != null&&!find)
                {
                    if (counter == index)
                    {
                        value = currentNode.Value;
                        find = true;
                    }
                    currentNode = currentNode.Next;
                    counter++;
                }
                return value;
            }
        }
    }
}
