using System;
using Strings;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите цифровую строку:");
            MyString str1 = new DigitalString(Console.ReadLine().ToCharArray());
            Console.WriteLine("Введите буквенную строку:");
            MyString str2 = new LettersString(Console.ReadLine().ToCharArray());
            str1 = str1.SubtractSymbol();
            Console.WriteLine("Строки после изменений:");
            Console.Write(str1.GetLine());
            Console.WriteLine(" : "+str1.GetLength());
            str2 = str2.SubtractSymbol();
            Console.Write(str2.GetLine());
            Console.WriteLine(" : " + str2.GetLength());
            Console.ReadKey();
        }
    }
}
