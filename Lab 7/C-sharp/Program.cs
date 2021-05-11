using System;

namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для расчёта выражения: (2 * c - lg(d / 4)) / (a * a - 1)");
            Expression[] expressions =
            {
                new Expression(1,2,3),
                new Expression(2,2,2),
                new Expression(-2,3,-3)
            };
            for (int i = 0; i < expressions.Length; i++)
            {
                try
                {
                    Console.WriteLine($"Значение выражения {i + 1}: {expressions[i].GetValue():F2}");
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine($"У выражении {i + 1}:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            //Expression expression = new Expression();
            //AdditionalFunctions.Menu(expression);
        }
    }
}
