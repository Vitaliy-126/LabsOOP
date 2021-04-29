using System;
using System.Threading;
using BoxOfficeBL;
namespace BoxOfficeCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            PosterPerformances posterPerformances = new PosterPerformances();
            BoxOffice boxOffice = new BoxOffice();
            posterPerformances.AddPerformance(new Performance("Тартюф", "Мольер", "Комедия", 1664));
            posterPerformances.AddPerformance(new Performance("Укрощение строптивой", "Уильям Шекспир", "Комедия", 1954));
            posterPerformances.AddPerformance(new Performance("Король забавляется", "Виктор Гюго", "Драма", 1832));
            boxOffice.AddInShow(posterPerformances[0],Convert.ToDateTime("29-04-2021"),70);
            boxOffice.AddInShow(posterPerformances[0], Convert.ToDateTime("29-04-2021"), 70);
            boxOffice.AddInShow(posterPerformances[1], Convert.ToDateTime("29-04-2021"), 100);

            int choice;
            bool exit = false;
            do
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("0. Завершить програму");
                Console.WriteLine("1. Посмотреть афишу представлений");
                Console.WriteLine("2. Перейти в кассу");
                Console.Write("Ваш выбор: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.WriteLine("Перед вами афиша представлений. Выберите интересующее вас, введя соответсвующую цифру: ");
                        Console.WriteLine($"Текущая дата: {DateTime.Now.ToString("dd.MM.yyyy")}");
                        break;
                    case 2:
                        Console.WriteLine("Переходим в кассу...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Сеансы на сегодня: ");
                        break;
                }
            } while (!exit);
        }
    }
}
