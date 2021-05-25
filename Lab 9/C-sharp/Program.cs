using System;
using Library;
namespace C_sharp
{
    delegate int FirstDelegate(char symbol);
    delegate int SecondDelegate(MyString myString, char symbol);
    class Program
    {
        static void Main(string[] args)
        {
            int stackSize,choice;
            Console.Write("Введите размер стека: ");
            while (!int.TryParse(Console.ReadLine(), out stackSize)||stackSize<=0)
            {
                Console.Write("Вы ошиблись с вводом, попробуйте ещё раз: ");
            }
            Stack<int> stack = new Stack<int>(stackSize);
            stack.StackOverflow += (object source, StackEventArgs arg) => { Console.WriteLine($"Произошло переполнение стека\nМаксимальный размер: {arg.Size}"); };
            bool exit = false;
            do
            {
                Console.WriteLine("Меню[0-2]");
                Console.WriteLine("0. Выйти с меню стека");
                Console.WriteLine("1. Добавить элемент в стек");
                Console.WriteLine("2. Убрать элемент из стека");
                Console.Write("Ваш выбор: ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Вы ошиблись с вводом, попробуйте ещё раз: ");
                }
                switch (choice)

                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        int element;
                        Console.Write("Введите елемент: ");
                        while (!int.TryParse(Console.ReadLine(), out element))
                        {
                            Console.Write("Вы ошиблись с вводом, попробуйте ещё раз: ");
                        }
                        stack.Append(element);
                        break;
                    case 2:
                        try
                        {
                            stack.Pop();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            } while (!exit);
            Console.Write("Введите строку: ");
            string line = Console.ReadLine();
            MyString myString = new MyString(line.ToCharArray());
            char symbol;
            Console.Write("Введите символ: ");
            while (!char.TryParse(Console.ReadLine(), out symbol))
            {
                Console.Write("Вы ошиблись с вводом, попробуйте ещё раз: ");
            }
            FirstDelegate firstDelegate = myString.FindIndexSymbol;
            SecondDelegate secondDelegate = MyString.FindIndexSymbol;
            Console.WriteLine($"Результат работы первого делегата(экземплярный метод): {firstDelegate(symbol)}");
            Console.WriteLine($"Результат работы второго делегата(статический метод): {secondDelegate(myString,symbol)}");
            Console.ReadKey();
        }
    }
}
