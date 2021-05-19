using System;
using BoxOfficeBL.Model;

namespace BoxOfficeCMD.Interaction
{
    class AfficheInteraction
    {
        public static void Menu(PosterPerformances posterPerformances)
        {
            int choice;
            bool exit = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Перед вами афиша представлений.");
                Console.WriteLine($"Текущая дата: {DateTime.Now:dd.MM.yyyy}");
                Console.WriteLine();
                Console.WriteLine("0. Покинуть афишу представлений");
                Console.WriteLine("1. Посмотреть афишу представлений");
                Console.WriteLine("2. Поиск за автором");
                Console.WriteLine("3. Поиск за названием");
                Console.WriteLine("4. Поиск за жанром");
                Console.WriteLine("5. Поиск за годом произведения");
                Console.WriteLine();
                Console.Write("Ваш выбор: ");
                
                    while(!int.TryParse(Console.ReadLine() ,out choice))
                    {
                        Console.Write("Вы ошиблись с вводом, повторите: ");
                    }
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            exit = true;
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\t\t\tАфиша представлений на данный момент:");
                            foreach (Poster poster in posterPerformances.Posters)
                            {
                                Console.WriteLine($"\t{AdditionalFunctions.StrPerformance(poster.Performance)}");
                                Console.Write("Доступно у дни: ");
                                foreach(DateTime date in poster.Dates)
                                {
                                    Console.Write($"{date:dd.MM} ");
                                }
                                Console.WriteLine();
                            }
                            break;
                        case 2:
                            Console.Clear();
                            string author;
                            Console.Write("Введите автора: ");
                            author = Console.ReadLine();
                            Console.WriteLine("Результаты:");
                            foreach (Poster poster in posterPerformances.SearchForAuthor(author))
                            {
                                Console.WriteLine($"\t{AdditionalFunctions.StrPerformance(poster.Performance)}");
                                Console.Write("Доступно у дни: ");
                                foreach (DateTime date in poster.Dates)
                                {
                                    Console.Write($"{date:dd.MM} ");
                                }
                                Console.WriteLine();
                            }
                            break;
                        case 3:
                            Console.Clear();
                            string title;
                            Console.Write("Введите название: ");
                            title = Console.ReadLine();
                            Console.WriteLine("Результаты:");
                            foreach (Poster poster in posterPerformances.SearchForTitle(title))
                            {
                                Console.WriteLine($"\t{AdditionalFunctions.StrPerformance(poster.Performance)}");
                                Console.Write("Доступно у дни: ");
                                foreach (DateTime date in poster.Dates)
                                {
                                    Console.Write($"{date:dd.MM} ");
                                }
                                Console.WriteLine();
                            }
                            break;
                        case 4:
                            Console.Clear();
                            string genre;
                            Console.Write("Введите жанр: ");
                            genre = Console.ReadLine();
                            Console.WriteLine("Результаты:");
                            foreach (Poster poster in posterPerformances.SearchForGenre(genre))
                            {
                                Console.WriteLine($"\t{AdditionalFunctions.StrPerformance(poster.Performance)}");
                                Console.Write("Доступно у дни: ");
                                foreach (DateTime date in poster.Dates)
                                {
                                    Console.Write($"{date:dd.MM} ");
                                }
                                Console.WriteLine();
                            }
                            break;
                        case 5:
                            Console.Clear();
                            int year;
                            Console.Write("Введите год произведения: ");
                            year = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Результаты:");
                            foreach (Poster poster in posterPerformances.SearchForYear(year))
                            {
                                Console.WriteLine($"\t{AdditionalFunctions.StrPerformance(poster.Performance)}");
                                Console.Write("Доступно у дни: ");
                                foreach (DateTime date in poster.Dates)
                                {
                                    Console.Write($"{date:dd.MM} ");
                                }
                                Console.WriteLine();
                            }
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
            } while (!exit);
        }
    }
}

