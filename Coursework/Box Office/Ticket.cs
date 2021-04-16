using System;

namespace BoxOffice
{

    public enum TicketStatus
    {
        InStock,
        Booked,
        Sold
    }

    public class Ticket
    {
        public Ticket(DateTime date, decimal price, int row, int seat, string hall)
        {
            Date = date;
            Price = price;
            Hall = hall;
            Row = row;
            Seat = seat;
        }
        public TicketStatus Status { get; set; }
        public DateTime Date { get; }
        public decimal Price { get; }
        public string Hall { get; }
        public int Row { get; }
        public int Seat { get; }
    }
}
