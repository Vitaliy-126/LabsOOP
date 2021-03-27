namespace Library
{
    class MyString
    {

        public MyString()
        {
            length = 0;
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

        public MyString(in MyString other)
        {
            length = other.length;
            str = new char[length];
            for (int i = 0; i < length; i++)
            {
                str[i] = other.str[i];
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
        }

        public char[] Line
        {
            get
            {
                return str;
            }
        }

        public static MyString operator + (in MyString left,in MyString right)
        {
            MyString newStr = new MyString();
            newStr.length = left.length + right.length;
            newStr.str = new char[newStr.length];
            int i;
            for (i=0; i < left.length; i++)
            {
                newStr.str[i] = left.str[i];
            }
            for(int j = 0; j < right.length; j++, i++)
            {
                newStr.str[i] = right.str[j];
            }
            return newStr;
        }

        public static MyString operator + (in MyString left, char symbol)
        {
            MyString newStr = new MyString();
            newStr.length = left.length + 1;
            newStr.str = new char[newStr.length];
            int i;
            for (i = 0; i < left.length; i++)
            {
                newStr.str[i] = left.str[i];
            }
            newStr.str[newStr.length] = symbol;
            return newStr;
        }

        public static MyString operator - (in MyString left, char symbol)
        {
            int counter = 0;
            for(int i = 0; i < left.length; i++)
            {
                if (left.str[i] == symbol)
                {
                    counter++;
                }
            }
            MyString newStr = new MyString();
            newStr.length = left.length - counter;
            newStr.str = new char[newStr.length];
            int pos = 0;
            for(int i = 0; i < left.length; i++)
            {
                if (left.str[i] != symbol)
                {
                    newStr.str[pos] = left.str[i];
                    pos++;
                }
            }
            return newStr;
        }

        private char[] str;
        private int length;
    }
}
