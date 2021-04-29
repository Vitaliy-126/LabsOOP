using System;
using System.Collections.Generic;

namespace BoxOfficeBL
{
    public class PerformanceTickets
    {
        public PerformanceTickets(Performance performance, List<Ticket> tickets)
        {
            Performance = performance;
            Tickets = tickets;
        }
        public Performance Performance { get; }
        public List<Ticket> Tickets { get; }
    }
    public class BoxOffice
    {
        private Dictionary<DateTime, List<PerformanceTickets>> InShow;
        public BoxOffice()
        {
            InShow = new Dictionary<DateTime, List<PerformanceTickets>>();
        }
        public void AddInShow(Performance performance, DateTime date, int quantityTickets)
        {
            if (quantityTickets < 0)
            {
                throw new ArgumentException("the number of tickets cannot be negative");
            }
            if(performance == null)
            {
                throw new ArgumentNullException();
            }
            List<Ticket> tickets = new List<Ticket>();
            int row = 1,
                seat = 1;
            for (int i = 1; i <= quantityTickets; i++)
            {
                tickets.Add(new Ticket(performance.Title, date, 100,row,seat));
                if ((i) % 10 == 0)
                {
                    row++;
                    seat = 1;
                }
                tickets.Add(new Ticket(performance.Title, date, 100, row, seat));
                seat++;
            }
            try
            {
                InShow[date].Add(new PerformanceTickets(performance, tickets));
            }
            catch(KeyNotFoundException)
            {
                List<PerformanceTickets> performanceTickets = new List<PerformanceTickets>();
                performanceTickets.Add(new PerformanceTickets(performance, tickets));
                InShow.Add(date, performanceTickets);
            }
        }
        //public void DeleteInShow(Performance performance)
        //{
        //    foreach(Performance item in InShow.Keys)
        //    {
        //        if (item == performance)
        //        {
        //            InShow.Remove(performance);
        //        }
        //    }
        //}
        public void SellTicket(Performance performance, DateTime date, int row, int seat)
        {
            if (InShow != null)
            {
                int index = -1;
                foreach(PerformanceTickets performanceTickets in InShow[date])
                {
                    index++;
                    if(performanceTickets.Performance == performance)
                    {
                        for(int i = 0; i < InShow[date][index].Tickets.Count; i++)
                        {
                            if(InShow[date][index].Tickets[i].Row==row&& InShow[date][index].Tickets[i].Seat == seat)
                            {
                                if (InShow[date][index].Tickets[i].Status != TicketStatus.Sold && InShow[date][index].Tickets[i].Status != TicketStatus.Booked)
                                {
                                    InShow[date][index].Tickets[i].Status = TicketStatus.Sold;
                                }
                                else
                                {
                                    throw new Exception("Ticket sold or booked");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                throw new NotFoundException("There are currently no tickets available for this performance.");
            }
        }
        public void BookTicket(Performance performance, DateTime date, int row, int seat)
        {
            if (InShow != null)
            {
                int index = -1;
                foreach (PerformanceTickets performanceTickets in InShow[date])
                {
                    index++;
                    if (performanceTickets.Performance == performance)
                    {
                        for (int i = 0; i < InShow[date][index].Tickets.Count; i++)
                        {
                            if (InShow[date][index].Tickets[i].Row == row && InShow[date][index].Tickets[i].Seat == seat)
                            {
                                if (InShow[date][index].Tickets[i].Status != TicketStatus.Sold && InShow[date][index].Tickets[i].Status != TicketStatus.Booked)
                                {
                                    InShow[date][index].Tickets[i].Status = TicketStatus.Booked;
                                }
                                else
                                {
                                    throw new Exception("Ticket sold or booked");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                throw new NotFoundException("There are currently no tickets available for this performance.");
            }
        }
        //public PerformanceTickets Sessions(DateTime date)
        //{
            
        //    return InShow[date];
        //}
    }
}
