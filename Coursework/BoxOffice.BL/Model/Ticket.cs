using System;

namespace BoxOfficeBL
{
    public enum TicketStatus
    {
        InStock,
        Booked,
        Sold
    }
    public class Ticket
    {
        public Ticket(string title, DateTime date, decimal price,int row,int seat)
        {
            Title = title;
            Date = date;
            Price = price;
            Row = row;
            Seat = seat;
        }
        public string Title { get; }
        public TicketStatus Status { get; set; }
        public DateTime Date { get; }
        public decimal Price { get; }
        public int Row { get; }
        public int Seat { get; }
    }
}
