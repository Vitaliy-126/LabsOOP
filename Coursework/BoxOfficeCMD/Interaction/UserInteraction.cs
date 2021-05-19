using System;
using System.Threading;
using BoxOfficeBL.Model;

namespace BoxOfficeCMD.Interaction
{
    public class UserInteraction
    {
        public static void Menu(PosterPerformances posterPerformances, BoxOffice boxOffice)
        {
            int choice;
            bool exit = false;
            do
            {
                    Console.WriteLine("\t\tВас приветствует театральная касса села Борки!");
                    Console.WriteLine();
                    Console.WriteLine("Меню:");
                    Console.WriteLine("0. Завершить програму");
                    Console.WriteLine("1. Перейти в афишу представлений");
                    Console.WriteLine("2. Перейти в кассу");
                    Console.Write("Ваш выбор: ");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.Write("Вы ошиблись с вводом, повторите: ");
                    }
                switch (choice)
                    {
                        case 0:
                            exit = true;
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Переходим в афишу представлений...");
                            Thread.Sleep(1000);
                            Console.Clear();
                            AfficheInteraction.Menu(posterPerformances);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Переходим в кассу...");
                            Thread.Sleep(1000);
                            Console.Clear();
                            BoxOfficeInteraction.Menu(boxOffice);
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
            } while (!exit);
        }
    }
}
