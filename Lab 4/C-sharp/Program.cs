using System;
using Library;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString S1 = new MyString();
            Console.WriteLine("Введите строку S2:");
            MyString S2 = new MyString(input());
            Console.WriteLine("Введите строку S3:");
            MyString S3 = new MyString(input());
            Console.Write("Введите символ, который желаете вычесть с S2: ");
            char symbol = Convert.ToChar(Console.ReadLine());
            S2 -= symbol;
            Console.WriteLine("Ваша строка S2:");
            Console.WriteLine(S2.Line);
            Console.WriteLine("Результат сложения S2 и S3:");
            S1 = S2 + S3;
            Console.WriteLine(S1.Line);
            Console.ReadKey();
        }

        static private char[] input()
        {
            char[] line = Console.ReadLine().ToCharArray();
            return line;
        }

    }
}
