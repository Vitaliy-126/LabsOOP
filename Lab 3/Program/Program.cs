using System;
using MyLibrary;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        { 
            bool[] array = { true, false, false };
            MyClass my=new MyClass();
            Console.WriteLine(my.Result);
            Console.ReadKey();
        }
    }
}
