using System;

namespace Library
{
    public class MyString
    {
        public char[] Line { get; }
        public int Length { get; }
        public MyString(char[] str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("Str cannot be null", nameof(str));
            }
            Length = str.Length;
            Line = new char[Length];
            for (int i = 0; i < Length; i++)
            {
                Line[i] = str[i];
            }
        }
        public int FindIndexSymbol(char symbol)
        {
            for(int i = 0; i < Length; i++)
            {
                if (Line[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int FindIndexSymbol(MyString myString, char symbol)
        {
            if (myString == null)
            {
                throw new ArgumentNullException("MyString cannot be null", nameof(myString));
            }
            for (int i = 0; i < myString.Length; i++)
            {
                if (myString.Line[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
