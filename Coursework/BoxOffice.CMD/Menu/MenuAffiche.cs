using System;
using BoxOfficeBL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfficeCMD
{
    public static class MenuAffiche
    {
        public static void Search(PosterPerformances posterPerformances)
        {
            int choice;
            bool exit = false;
            Console.WriteLine("Перед вами афиша представлений. Выберите интересующее вас, введя соответсвующую цифру: ");
            Console.WriteLine($"Текущая дата: {DateTime.Now:dd.MM.yyyy}");
            do
            {
                Console.WriteLine();
                Console.WriteLine("0. Покинуть афишу представлений");
                Console.WriteLine("1. Посмотреть афишу представлений");
                Console.WriteLine("2. Поиск за автором");
                Console.WriteLine("3. Поиск за названием");
                Console.WriteLine("4. Поиск за жанром");
                Console.WriteLine("5. Поиск за годом произведения");
                Console.WriteLine();
                Console.Write("Ваш выбор: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\t\t\tАфиша представлений на данный момент:");
                        foreach(Performance performance in posterPerformances.Performances)
                        {
                            Console.WriteLine($"\t{performance}");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        string author;
                        Console.Write("Введите автора: ");
                        author = Console.ReadLine();
                        foreach (Performance performance in posterPerformances.SearchForAuthor(author))
                        {
                            Console.WriteLine(performance);
                        }
                        break;
                    case 3:
                        Console.Clear();
                        string title;
                        Console.Write("Введите название: ");
                        title = Console.ReadLine();
                        foreach (Performance performance in posterPerformances.SearchForTitle(title))
                        {
                            Console.WriteLine(performance);
                        }
                        break;
                    case 4:
                        Console.Clear();
                        string genre;
                        Console.Write("Введите жанр: ");
                        genre = Console.ReadLine();
                        foreach (Performance performance in posterPerformances.SearchForGenre(genre))
                        {
                            Console.WriteLine(performance);
                        }
                        break;
                    case 5:
                        Console.Clear();
                        int year;
                        Console.Write("Введите дату произведения: ");
                        year = Convert.ToInt32(Console.ReadLine());
                        foreach (Performance performance in posterPerformances.SearchForYear(year))
                        {
                            Console.WriteLine(performance);
                        }
                        break;
                }
            } while (!exit);
        }
    }
}
