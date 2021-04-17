namespace Strings
{
    abstract public class MyString
    {
        public MyString()
        {

        }
        public MyString(char[] str)
        {
            length = str.Length;
            this.str = new char[length];
            for (int i = 0; i < length; i++)
            {
                this.str[i] = str[i];
            }
        }
        abstract public MyString SubtractSymbol();
        public virtual int GetLength()
        {
            return length;
        }
        public char[] GetLine()
        {
            return str;
        }
        protected char[] str;
        protected int length;

    }
}
