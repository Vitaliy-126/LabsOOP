using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOfficeCMD
{
    public static class Menu
    {
        public static void Purchase(BoxOfficeBL.BoxOffice boxOffice)
        {
            int choice = 0;
            bool resOperation = false;
            int indexPerf, row, seat;
            do
            {
                int index = 0;
                Console.WriteLine();
                Console.WriteLine("\t\t\tДоступные сегодня сеансы: ");
                foreach (var session in boxOffice.Sessions(DateTime.Now.Date))
                {
                    Console.WriteLine($"\t{session} - {index + 1}");
                    index++;
                }
                Console.Write("Выберите сеанс: ");
                indexPerf = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Clear();
                int counter = 0;
                List<DateTime> times = boxOffice.InfoPerformance(DateTime.Now, boxOffice[DateTime.Now, indexPerf]);
                foreach (DateTime time in times)
                {
                    counter++;
                    Console.WriteLine($"{time:T} - {counter}");
                }
                Console.Write("Выберите время сеанса: ");
                int indexTime = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Clear();
                Console.Write("Ряд: ");
                row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Место: ");
                seat = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (boxOffice.SellTicket(boxOffice[DateTime.Now, indexPerf], times[indexTime], row, seat))
                {
                    Console.WriteLine("Билет куплен успешно");
                    Thread.Sleep(1000);
                    Console.Clear();
                    resOperation = true;
                }
                else
                {
                    Console.WriteLine("Билет не удалось купить.");
                    Console.WriteLine("0. Вернуться назад");
                    Console.WriteLine("1. Попровать ещё раз");
                    Console.Write("Ваш выбор: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            resOperation = true;
                            break;
                        case 1:
                            break;
                    }
                    Console.Clear();
                }
            } while (!resOperation);
        }
        public static void Book(BoxOfficeBL.BoxOffice boxOffice)
        {
            int choice = 0;
            bool resOperation = false;
            int indexPerf, row, seat;
            do
            {
                int index = 0;

                Console.WriteLine("\t\t\tДоступные сегодня сеансы: ");
                foreach (var session in boxOffice.Sessions(DateTime.Now.Date))
                {
                    Console.WriteLine($"\t{session} - {index + 1}");
                    index++;
                }
                Console.Write("Выберите сеанс: ");
                indexPerf = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Clear();
                int counter = 0;
                List<DateTime> times = boxOffice.InfoPerformance(DateTime.Now, boxOffice[DateTime.Now, indexPerf]);
                foreach (DateTime time in times)
                {
                    counter++;
                    Console.WriteLine($"{time:T} - {counter}");
                }
                Console.Write("Выберите время сеанса: ");
                int indexTime = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Clear();
                Console.Write("Ряд: ");
                row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Место: ");
                seat = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (boxOffice.BookTicket(boxOffice[DateTime.Now, indexPerf], times[indexTime], row, seat))
                {
                    Console.WriteLine("Билет забронирован успешно");
                    Thread.Sleep(1000);
                    Console.Clear();
                    resOperation = true;
                }
                else
                {
                    Console.WriteLine("Билет не удалось забронировать.");
                    Console.WriteLine("0. Вернуться назад");
                    Console.WriteLine("1. Попровать ещё раз");
                    Console.Write("Ваш выбор: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            resOperation = true;
                            break;
                        case 1:
                            break;
                    }
                    Console.Clear();
                }
            } while (!resOperation);
        }
    }
}
