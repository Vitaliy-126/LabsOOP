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
            AdditionalFunctions.InputData(boxOffice);
            UserInteraction.Menu(posterPerformances, boxOffice);
        }
    }
}
