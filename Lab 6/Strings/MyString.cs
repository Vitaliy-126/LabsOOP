using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class MyString
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

        public virtual MyString SubtractSymbol(char symbol)
        {
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == symbol)
                {
                    counter++;
                }
            }
            MyString newStr = new MyString();
            newStr.length = length - counter;
            newStr.str = new char[newStr.length];
            int pos = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] != symbol)
                {
                    newStr.str[pos] = str[i];
                    pos++;
                }
            }
            return newStr;
        }

        public char[] Str
        {
            get
            {
                return str;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
        }

        protected char[] str;
        protected int length;

    }
}
