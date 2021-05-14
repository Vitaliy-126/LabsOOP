using BoxOfficeBL.AdditionalClasses;
using BoxOfficeBL.Model;
using System.Net;
using System.Net.Mail;

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
    }
}
