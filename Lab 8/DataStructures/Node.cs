namespace DataStructures
{
    public class Node
    {
        public short Value { get; }
        public Node Next { get; set; }
        public Node(short value)
        {
            Value = value;
        }
    }
}
