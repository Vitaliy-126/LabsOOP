using System;
using Library;
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            int size = Convert.ToInt32(Console.ReadLine());
            MyClass example;
            bool[] temp=new bool[size];
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < size; i++)
            {
                temp[i] = Convert.ToBoolean(Console.ReadLine());
            }
            example = new MyClass(temp);
            menu(example);
            Console.ReadKey();
        }

        static void menu(MyClass example)
        {
            int choice;
            bool exit = false;
            Console.WriteLine("Выберите один из пункта меню:");
            Console.WriteLine("Меню[0-2]:");
            Console.WriteLine("0. Завершить програму");
            Console.WriteLine("1. Вывести элемент массива");
            Console.WriteLine("2. Логическая сумма всех элементов");
            do
            {
                Console.Write("Ваш выбор: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        int index;
                        Console.WriteLine("Введите индекс массива");
                        index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(example[index]);
                        break;
                    case 2:
                        Console.WriteLine("Значение операции логической суммы всех элементов массива: "+example.Result);
                        break;
                }
            } while (!exit);
        }

    }
}
