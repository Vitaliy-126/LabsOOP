using System;

namespace Strings
{
    public class DigitalString : MyString
    {
        public DigitalString()
        {

        }
        public DigitalString(char[] str) : base(str)
        {
            for(int i = 0; i < length; i++)
            {
                if (!char.IsDigit(this.str[i])){
                    throw new Exception("it is impossible to create a digital string");
                }
            }
        }
        public override MyString SubtractSymbol()
        {
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == '5')
                {
                    counter++;
                }
            }
            DigitalString newStr = new DigitalString();
            newStr.length = length - counter;
            newStr.str = new char[newStr.length];
            int pos = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] != '5')
                {
                    newStr.str[pos] = str[i];
                    pos++;
                }
            }
            return newStr;
        }

    }
}
