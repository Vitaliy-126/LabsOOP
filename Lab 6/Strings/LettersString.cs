using System;

namespace Strings
{
    public class LettersString : MyString
    {
        public LettersString()
        {

        }
        public LettersString(char[]str) : base(str)
        {
            for (int i = 0; i < length; i++)
            {
                if (!char.IsLetter(this.str[i]))
                {
                    throw new Exception($"it is impossible to create a letters string");
                }
            }
        }
        public override MyString SubtractSymbol()
        {
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == 'а')
                {
                    counter++;
                }
            }
            LettersString newStr = new LettersString();
            newStr.length = length - counter;
            newStr.str = new char[newStr.length];
            int pos = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] != 'а')
                {
                    newStr.str[pos] = str[i];
                    pos++;
                }
            }
            return newStr;
        }

    }
}
