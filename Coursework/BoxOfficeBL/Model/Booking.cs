using System;

namespace BoxOfficeBL.Model
{
    public class Booking
    {
        public ClientInfo ClientInfo { get; }
        public DateTime UntilDateTime { get; }
        public Ticket Ticket { get; }
        public Booking(ClientInfo clientInfo, Ticket ticket, int minutes)
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
            if(minutes < 0)
            {
                throw new ArgumentException("Minutes cannot be negative", nameof(minutes));
            }
            #endregion
            ClientInfo = clientInfo;
            Ticket = ticket;
            UntilDateTime = DateTime.Now.AddMinutes(minutes);
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
