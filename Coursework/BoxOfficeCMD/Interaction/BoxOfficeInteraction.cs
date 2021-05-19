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
            int choice;
            bool ex = false;
            do
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("0. Выйти с кассы");
                Console.WriteLine("1. Показать сегодняшние представления:");
                Console.WriteLine("2. Купить билет");
                Console.WriteLine("3. Забронировать билет");
                Console.WriteLine("4. Купить забронированный билет");
                Console.Write("Ваш выбор: ");
                try
                {
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.Write("Вы ошиблись с вводом, повторите: ");
                    }
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            ex = true;
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("\t\t\tПредставления на сегодня: ");
                            foreach (Performance performance in boxOffice.AvailablePerformances(DateTime.Now.Date))
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
                        while (!int.TryParse(Console.ReadLine(), out quantityTickets)||quantityTickets<=0)
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
                                        while (!int.TryParse(Console.ReadLine(), out row))
                                        {
                                            Console.Write("Вы ошиблись с вводом, повторите: ");
                                        }
                                        Console.Write("Место: ");
                                        while (!int.TryParse(Console.ReadLine(), out seat))
                                        {
                                            Console.Write("Вы ошиблись с вводом, повторите: ");
                                        }
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
                                                while (!AdditionalFunctions.IsValidEmail(email))
                                                {
                                                    Console.Write("Некоректный email, попробуйте ещё раз: ");
                                                    email = Console.ReadLine();
                                                }
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
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        exit = true;
                                    }
                                }
                                catch (ArgumentException argEx)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(argEx.Message);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.WriteLine("На эту дату нету доступных представлений.");
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
            int indexPerf, row, seat;
            ClientInfo clientInfo;
            DateTime date, untilDateTime;
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
                        bool exit = false;
                            do
                            {
                                try
                                {
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
                                            while (!int.TryParse(Console.ReadLine(), out row))
                                            {
                                                Console.Write("Вы ошиблись с вводом, повторите: ");
                                            }
                                            Console.Write("Место: ");
                                            while (!int.TryParse(Console.ReadLine(), out seat))
                                            {
                                                Console.Write("Вы ошиблись с вводом, повторите: ");
                                            }
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
                                                while (!AdditionalFunctions.IsValidEmail(email))
                                                {
                                                    Console.Write("Некоректный email, попробуйте ещё раз: ");
                                                    email = Console.ReadLine();
                                                }
                                                clientInfo = new ClientInfo(name, surname, email);
                                                Console.Write("Введите дату и время окончания брони(MM.dd.yyyy HH: mm): ");
                                                while (!DateTime.TryParse(Console.ReadLine(), out untilDateTime))
                                                {
                                                    Console.Write("Неправильный формат, попробуйте ещё раз: ");
                                                }
                                                if (boxOffice.BookTicket(boxOffice[date, indexPerf], times[indexTime], row, seat, clientInfo, untilDateTime))
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
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            exit = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Нету доступных мест.");
                                        Thread.Sleep(2000);
                                        exit = true;
                                        Console.Clear();
                                    }
                                }
                                catch (ArgumentException argEx)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(argEx.Message);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    Console.ResetColor();
                                }
                            } while (!exit);
                    }
                    else Console.Clear();
                }
                else Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("На эту дату нету доступных представлений.");
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

