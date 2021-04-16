using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
    class Ticket
    {
        public Ticket(DateTime date, decimal price, int row, int seat, string hall)
        {
            Date = date;
            Price = price;
            Hall = hall;
            Row = row;
            Seat = seat;
        }
        public DateTime Date { get; }
        public decimal Price { get; }
        public string Hall { get; }
        public int Row { get; }
        public int Seat { get; }
    }
}
