using System;
using System.Collections.Generic;
using System.Threading;
using BoxOfficeBL.Model;

namespace BoxOfficeCMD.Interaction
{
    class BoxOfficeInteraction
    {
        public static void Menu(BoxOffice boxOffice)
        {
            DateTime date = DateTime.Now.Date;
            int choice;
            bool ex = false;
            do
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("0. Выйти с кассы");
                Console.WriteLine("1. Показать сегодняшние сеансы:");
                Console.WriteLine("2. Купить билет");
                Console.WriteLine("3. Забронировать билет");
                Console.WriteLine("4. Купить забронированный билет");
                Console.Write("Ваш выбор: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            ex = true;
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\t\t\tСеансы на сегодня: ");
                            foreach (Performance performance in boxOffice.AvailablePerformances(date))
                            {
                                Console.WriteLine($"\t{AdditionalFunctions.StrPerformance(performance)}");
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Purchase(boxOffice);
                            break;
                        case 3:
                            Console.Clear();
                            Book(boxOffice);
                            break;
                        case 4:
                            Console.Clear();
                            BuyReservation(boxOffice);
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception exe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(exe.Message);
                    Thread.Sleep(1500);
                    Console.Clear();
                    Console.ResetColor();
                }
            } while (!ex);
        }
        static void Purchase(BoxOffice boxOffice)
        {
            int indexPerf, row, seat;
            string email = "";
            DateTime date;
            Console.Write("Введите желаемую дату(dd.MM.yyyy): ");
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Неправильный формат даты, попробуйте ещё раз: ");
            }
            int index = 0;
            Console.WriteLine();
            Console.WriteLine("\t\t\tДоступные представления: ");
            foreach (var performance in boxOffice.AvailablePerformances(date))
            {
                Console.WriteLine($"\t{AdditionalFunctions.StrPerformance(performance)} - {index + 1}");
                index++;
            }
            if (index > 0) { 
                Console.WriteLine("0. Покинуть меню покупки");
                Console.Write("Ваш выбор: ");
                while (!int.TryParse(Console.ReadLine(), out indexPerf) || indexPerf < 0 || indexPerf > index)
                {
                    Console.Write("Вы ошиблись с вводом, повторите: ");
                }
                if (indexPerf != 0)
                {
                    Console.Clear();
                    indexPerf--;
                    int counter = 0;
                    List<DateTime> times = boxOffice.TimesPerformance(date, boxOffice[date, indexPerf]);
                    foreach (DateTime time in times)
                    {
                        counter++;
                        Console.WriteLine($"{time:T} - {counter}");
                    }
                    Console.WriteLine("0. Покинуть меню покупки");
                    Console.Write("Ваш выбор: ");
                    int indexTime;
                    while (!int.TryParse(Console.ReadLine(), out indexTime) || indexTime < 0 || indexTime > counter)
                    {
                        Console.Write("Вы ошиблись с вводом, повторите: ");
                    }
                    if (indexTime != 0)
                    {
                        indexTime--;
                        int quantityTickets, item = 0;
                        bool exit = false;
                        bool places = false;
                        Console.Write("Введите желаемое количество билетов: ");
                        while (!int.TryParse(Console.ReadLine(), out quantityTickets))
                        {
                            Console.Write("Вы ошиблись с вводом, повторите: ");
                        }
                        Console.Clear();
                        while (item < quantityTickets && !exit)
                        {
                            Console.Clear();
                            bool[,] seats = boxOffice.SeatsPerformance(times[indexTime], boxOffice[date, indexPerf]);
                            Console.Clear();
                            Console.SetCursorPosition(seats.GetLength(1) * 2, 0);
                            Console.WriteLine("Зал");
                            Console.SetCursorPosition(0, 1);
                            for (int i = 0; i < seats.GetLength(0); i++)
                            {
                                for (int j = 0; j < seats.GetLength(1); j++)
                                {
                                    if (seats[i, j] == true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("   #");
                                        places = true;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("   #");
                                    }
                                }
                                Console.WriteLine();
                            }
                            Console.ResetColor();
                            if (places)
                            {
                                try
                                {
                                    int select;
                                    Console.WriteLine("0. Покинуть меню покупки");
                                    Console.WriteLine("1. Выбрать ряд и место");
                                    Console.Write("Ваш выбор: ");
                                    while (!int.TryParse(Console.ReadLine(), out select) || select != 0 && select != 1)
                                    {
                                        Console.Write("Вы ошиблись с вводом, повторите: ");
                                    }
                                    if (select == 1)
                                    {
                                        Console.Write("Ряд: ");
                                        row = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Место: ");
                                        seat = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine($"Цена билета составит: {boxOffice.GetTicketPrice(boxOffice[date, indexPerf], times[indexTime], row, seat)}");
                                        string choice;
                                        do
                                        {
                                            Console.Write("Подтвердить(Yes/No): ");
                                            choice = Console.ReadLine();
                                        } while (choice.ToLower() != "yes" && choice.ToLower() != "no");
                                        if (choice == "yes")
                                        {
                                            if (string.IsNullOrEmpty(email))
                                            {
                                                Console.Write("Введите email: ");
                                                email = Console.ReadLine();
                                            }

                                            if (boxOffice.SellTicket(boxOffice[date, indexPerf], times[indexTime], row, seat, email))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Билет куплен успешно");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                item++;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Билет не удалось купить");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            exit = true;
                                        }
                                    }
                                    else Console.Clear();
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Нету доступных мест.");
                                Thread.Sleep(2000);
                                Console.Clear();
                                exit = true;
                            }
                        }
                    }
                    else Console.Clear();
                }
                else Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("На даный момент нет доступных сеансов");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        static void Book(BoxOffice boxOffice)
        {
            int indexPerf, row, seat, minutes;
            ClientInfo clientInfo;
            DateTime date;
            Console.Write("Введите желаемую дату(dd.MM.yyyy): ");
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Write("Неправильный формат даты, попробуйте ещё раз: ");
            }
            int index = 0;
            Console.WriteLine();
            Console.WriteLine("\t\t\tДоступные представления: ");
            foreach (var performance in boxOffice.AvailablePerformances(date))
            {
                Console.WriteLine($"\t{AdditionalFunctions.StrPerformance(performance)} - {index + 1}");
                index++;
            }
            if (index > 0) { 
                Console.WriteLine("0. Покинуть меню бронирования");
                Console.Write("Ваш выбор: ");
                while (!int.TryParse(Console.ReadLine(), out indexPerf) || indexPerf < 0 || indexPerf > index)
                {
                    Console.Write("Вы ошиблись с вводом, повторите: ");
                }
                if (indexPerf != 0)
                {
                    Console.Clear();
                    indexPerf--;
                    int counter = 0;
                    List<DateTime> times = boxOffice.TimesPerformance(date, boxOffice[date, indexPerf]);
                    foreach (DateTime time in times)
                    {
                        counter++;
                        Console.WriteLine($"{time:T} - {counter}");
                    }
                    Console.WriteLine("0. Покинуть меню бронирования");
                    Console.Write("Ваш выбор: ");
                    int indexTime;
                    while (!int.TryParse(Console.ReadLine(), out indexTime) || indexTime < 0 || indexTime > counter)
                    {
                        Console.Write("Вы ошиблись с вводом, повторите: ");
                    }
                    if (indexTime != 0)
                    {
                        indexTime--;
                        bool places = false;
                        Console.Clear();
                        bool[,] seats = boxOffice.SeatsPerformance(times[indexTime], boxOffice[date, indexPerf]);
                        Console.Clear();
                        Console.SetCursorPosition(seats.GetLength(1) * 2, 0);
                        Console.WriteLine("Зал");
                        Console.SetCursorPosition(0, 1);
                        for (int i = 0; i < seats.GetLength(0); i++)
                        {
                            for (int j = 0; j < seats.GetLength(1); j++)
                            {
                                if (seats[i, j] == true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("   #");
                                    places = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("   #");
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.ResetColor();
                        bool exit = false;
                        if (places)
                        {
                            do
                            {
                                try
                                {
                                    int select;
                                    Console.WriteLine("0. Покинуть меню бронирования");
                                    Console.WriteLine("1. Выбрать ряд и место");
                                    Console.Write("Ваш выбор: ");
                                    while (!int.TryParse(Console.ReadLine(), out select) || select != 0 && select != 1)
                                    {
                                        Console.Write("Вы ошиблись с вводом, повторите: ");
                                    }
                                    if (select == 1)
                                    {
                                        Console.Write("Ряд: ");
                                        row = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Место: ");
                                        seat = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine($"Цена билета составит: {boxOffice.GetTicketPrice(boxOffice[date, indexPerf], times[indexTime], row, seat)}");
                                        string choice;
                                        do
                                        {
                                            Console.Write("Подтвердить(Yes/No): ");
                                            choice = Console.ReadLine();
                                        } while (choice.ToLower() != "yes" && choice.ToLower() != "no");
                                        if (choice == "yes")
                                        {
                                            string name, surname, email;
                                            Console.WriteLine("Чтобы забронировать билет введите дополнительные данные:");
                                            Console.Write("Ваше имя: ");
                                            name = Console.ReadLine();
                                            Console.Write("Ваша Фамилия: ");
                                            surname = Console.ReadLine();
                                            Console.Write("Ваш email: ");
                                            email = Console.ReadLine();
                                            clientInfo = new ClientInfo(name, surname, email);
                                            Console.Write("Введите длительность брони(у минутах): ");
                                            minutes = Convert.ToInt32(Console.ReadLine());
                                            if (boxOffice.BookTicket(boxOffice[date, indexPerf], times[indexTime], row, seat, clientInfo, minutes))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Билет забронирован успешно");
                                                exit = true;
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Билет не удалось забронировать");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            exit = true;
                                        }
                                    }
                                    else Console.Clear();
                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.ResetColor();
                                }
                            } while (!exit);
                        }
                        else
                        {
                            Console.WriteLine("Нету доступных мест.");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                    }
                    else Console.Clear();
                }
                else Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("На даный момент нет доступных сеансов");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        static void BuyReservation(BoxOffice boxOffice)
            {
                string name, surname, email;
                Console.WriteLine("Введите данные, заполненые вами при бронировке:");
                Console.Write("Ваше имя: ");
                name = Console.ReadLine();
                Console.Write("Ваша Фамилия: ");
                surname = Console.ReadLine();
                Console.Write("Ваш email: ");
                email = Console.ReadLine();
                if (boxOffice.SellReservation(new ClientInfo(name, surname, email)))
                {
                    Console.Clear();
                    Console.WriteLine("Билет куплен успешно");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Этот человек не бронировал у нас билет");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
    }
}

