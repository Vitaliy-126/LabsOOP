using System;

namespace BoxOfficeBL.Model
{
    public enum TicketStatus
    {
        InStock,
        Booked,
        Sold
    }
    public class Ticket
    {
        public string Title { get; }
        public TicketStatus Status { get; set; }
        public DateTime DateTime { get; }
        public decimal Price { get; }
        public int Row { get; }
        public int Seat { get; }
        public Ticket(string title, DateTime dateTime, decimal price, int row, int seat)
        {
            #region verify the conditions
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Performance title cannot be empty or null", nameof(title));
            }

            if (dateTime < DateTime.Now)
            {
                throw new ArgumentException("Ticket date cannot be retroactive", nameof(dateTime));
            }

            if (price < 0)
            {
                throw new ArgumentException("The ticket price cannot be negative", nameof(price));
            }

            if (row <= 0)
            {
                throw new ArgumentException("Row cannot be negative or zero", nameof(row));
            }

            if (seat <= 0)
            {
                throw new ArgumentException("Seat cannot be negative or zero", nameof(seat));
            }
            #endregion
            Title = title;
            DateTime = dateTime;
            Price = price;
            Row = row;
            Seat = seat;
        }
    }
}
