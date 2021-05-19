using System;

namespace BoxOfficeBL.Model
{
    public class Booking
    {
        public ClientInfo ClientInfo { get; }
        public DateTime UntilDateTime { get; }
        public Ticket Ticket { get; }
        public Booking(ClientInfo clientInfo, Ticket ticket, DateTime untilDateTime)
        {
            #region verify the conditions 
            if (clientInfo == null)
            {
                throw new ArgumentNullException("ClientInfo cannot be null", nameof(clientInfo));
            }
            if(ticket == null)
            {
                throw new ArgumentNullException("Ticket cannot be null", nameof(ticket));
            }
            if(untilDateTime<=DateTime.Now)
            {
                throw new ArgumentException("Invalid booking date", nameof(untilDateTime));
            }
            #endregion
            ClientInfo = clientInfo;
            Ticket = ticket;
            UntilDateTime = untilDateTime;
        }
        public bool IsActual()
        {
            if (DateTime.Now > UntilDateTime)
            {
                return false;
            }
            return true;
        }
    }
}
