using System;

namespace C_sharp
{
    public static class AdditionalFunctions
    {
        public static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Меню[0-2]:");
            Console.WriteLine("0. Завершить програму");
            Console.WriteLine("1. Установить значения выражению");
            Console.WriteLine("2. Вычислить значение выражения");
            Console.ResetColor();
        }
        public static void Menu(Expression expression)
        {
            Console.WriteLine($"Программа для расчёта выражения: {expression}");
            bool exit = false;
            int choice;
            do
            {
                PrintMenu();
                try
                {
                    Console.Write("Ваш выбор: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            exit = true;
                            break;
                        case 1:
                            Console.Write("a = ");
                            expression.A = Convert.ToDouble(Console.ReadLine());
                            Console.Write("c = ");
                            expression.C = Convert.ToDouble(Console.ReadLine());
                            Console.Write("d = ");
                            expression.D = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Значение выражения: {0:F2}", expression.GetValue());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            } while (!exit);
        }
    }
}
