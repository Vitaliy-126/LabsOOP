using System;
using BoxOfficeBL.AdditionalClasses;
using BoxOfficeBL.Model;
using BoxOfficeCMD.Interaction;

namespace BoxOfficeCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            PosterPerformances posterPerformances = new PosterPerformances();
            BoxOffice boxOffice = new BoxOffice();
            boxOffice.PerformanceAdded += (object source, PerformanceEventArgs arg) => { posterPerformances.AddPoster(new Poster(arg.Performance, arg.Date)); };
            boxOffice.PerformanceDeleted += (object source, PerformanceEventArgs arg) => { posterPerformances.DeletePoster(new Poster(arg.Performance, arg.Date)); };
            boxOffice.TicketSold += AdditionalFunctions.SendingTicket;
            boxOffice.AddInShow(new Performance("Тартюф", "Мольер", "Комедия", 1664), new Hall("Главный зал", 10, 10), Convert.ToDateTime("12-05-2021 19:40"), 100);
            boxOffice.AddInShow(new Performance("Тартюф", "Мольер", "Комедия", 1664), new Hall("Главный зал", 10, 10), Convert.ToDateTime("12-05-2021 18:40"), 150);
            boxOffice.AddInShow(new Performance("Укрощение строптивой", "Уильям Шекспир", "Комедия", 1954), new Hall("Главный зал", 10, 10), Convert.ToDateTime("12-05-2021 20:40"), 120);
            boxOffice.AddInShow(new Performance("Укрощение строптивой", "Уильям Шекспир", "Комедия", 1954), new Hall("Главный зал", 10, 10), Convert.ToDateTime("12-05-2021 19:40"), 120);
            boxOffice.AddInShow(new Performance("Король забавляется", "Виктор Гюго", "Драма", 1832), new Hall("Главный зал", 10, 10), Convert.ToDateTime("13-05-2021 20:40"), 200);
            UserInteraction.Menu(posterPerformances, boxOffice);
        }
    }
}
