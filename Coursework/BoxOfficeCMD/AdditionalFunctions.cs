using BoxOfficeBL.AdditionalClasses;
using BoxOfficeBL.Model;
using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace BoxOfficeCMD
{
    public static class AdditionalFunctions
    {
        public static void SendingTicket(object source, TicketEventArgs args)
        {
            MailAddress fromAdress = new MailAddress("boxoffice.birky@gmail.com", "Театральна каса села Бірки");
            MailAddress toaddress = new MailAddress(args.CommunicationMedium);
            MailMessage message = new MailMessage(fromAdress, toaddress);
            Ticket ticket = args.Ticket;
            message.Body = $"Ваш билет:\n" +
                $"Название представления: \"{ticket.Title}\"\n" +
                $"Ряд: {ticket.Row}\n" +
                $"Место: {ticket.Seat}\n" +
                $"Дата и время: {ticket.DateTime:g}\n" +
                $"Цена: {ticket.Price}\n" +
                $"Приятного просмотра!";
            message.Subject = "Спасибо за покупку билета!";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(fromAdress.Address, "forCoursework2021");
            smtpClient.Send(message);
        }
        public static string StrPerformance(Performance performance)
        {
            return $"Название: \"{performance.Title}\"({performance.Year}). Автор: {performance.Author}. Жанр: {performance.Genre}.";
        }
        public static void InputData(BoxOffice boxOffice)
        {
            Hall firstHall = new Hall("Зал 1", 15, 15);
            Hall secondHall = new Hall("Зал 2", 25, 25);
            try { boxOffice.AddInShow(new Performance("Гамлет", "Уильям Шекспир", "Трагедия", 1601), firstHall, DateTime.Now.Date.AddHours(19.5), 100); } catch { }
            try { boxOffice.AddInShow(new Performance("Месяц в деревне", "Тургенев", "Пьеса", 1855), secondHall, DateTime.Now.Date.AddHours(19.5), 200); } catch { }
            try { boxOffice.AddInShow(new Performance("Гамлет", "Уильям Шекспир", "Трагедия", 1601), firstHall, DateTime.Now.Date.AddHours(21.5), 150); } catch { }
            boxOffice.AddInShow(new Performance("Ромео и Джульетта", "Уильям Шекспир", "Трагедия", 1595), firstHall, DateTime.Now.Date.AddDays(1).AddHours(20), 150);
            boxOffice.AddInShow(new Performance("Пигмалион", "Бернард Шоу", "Комедия", 1913), secondHall, DateTime.Now.Date.AddDays(1).AddHours(20), 120);
            boxOffice.AddInShow(new Performance("Месяц в деревне", "Тургенев", "Пьеса", 1855), secondHall, DateTime.Now.Date.AddDays(1).AddHours(18), 200);
            boxOffice.AddInShow(new Performance("Утиная охота", "Александр Вампилов", "Драма", 1967), secondHall, DateTime.Now.Date.AddDays(2).AddHours(20), 120);
            boxOffice.AddInShow(new Performance("Ревизор", "Гоголь", "Комедия", 1835), firstHall, DateTime.Now.Date.AddDays(2).AddHours(19.5), 200);
            boxOffice.AddInShow(new Performance("Месяц в деревне", "Тургенев", "Пьеса", 1855), new Hall("Главный зал", 10, 10), DateTime.Now.Date.AddDays(3).AddHours(19.5), 200);
        }
        public static bool IsValidEmail(string email)
        {
            Regex myReg = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+");
            return myReg.IsMatch(email);
        }
    }
}
