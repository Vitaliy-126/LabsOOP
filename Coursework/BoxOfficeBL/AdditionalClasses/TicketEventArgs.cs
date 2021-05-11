using BoxOfficeBL.Model;

namespace BoxOfficeBL.AdditionalClasses
{
    public delegate void TicketHandler(object sender, TicketEventArgs args);
    public class TicketEventArgs
    {
        public Ticket Ticket { get; }
        public string CommunicationMedium { get; }
        public TicketEventArgs(Ticket ticket, string communicationMedium)
        {
            Ticket = ticket;
            CommunicationMedium = communicationMedium;
        }
    }
}
