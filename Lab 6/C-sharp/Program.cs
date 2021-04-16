using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strings;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            LettersString letters = new LettersString("yaebal".ToCharArray());
            MyString my = letters;
            Console.WriteLine(letters.Str);
            my = my.SubtractSymbol();
            Console.WriteLine(my.Str);
            Console.ReadKey();
        }
    }
}
