using System;
using System.Collections.Generic;
using BoxOfficeBL.AdditionalClasses;

namespace BoxOfficeBL.Model
{
    public class PerformanceTickets
    {
        public PerformanceTickets(Performance performance, Hall hall, List<Ticket> tickets, DateTime dateTime)
        {
            #region verify the conditions
            if (performance == null)
            {
                throw new ArgumentNullException("Performance cannot be null.", nameof(performance));
            }

            if (tickets == null)
            {
                throw new ArgumentException("Tickets cannot be null.", nameof(tickets));
            }

            if (hall == null)
            {
                throw new ArgumentException("Hall cannot be null.", nameof(tickets));
            }
            #endregion
            Performance = performance;
            Hall = hall;
            Tickets = tickets;
            AvailableTickets = tickets.Count;
            DateTime = dateTime;
            bookings = new List<Booking>();
        }
        public int AvailableTickets { get; set; }
        public Performance Performance { get; }
        public IReadOnlyList<Ticket> Tickets { get; }
        public DateTime DateTime { get; }
        public Hall Hall { get; }
        public bool[,] Seats(int rows, int cols)
        {
            UpdateTickets();
            bool[,] seats = new bool[rows, cols];
            foreach(Ticket ticket in Tickets)
            {
                if (ticket.Status == TicketStatus.InStock)
                {
                    seats[ticket.Row - 1, ticket.Seat - 1] = true;
                }
                else seats[ticket.Row - 1, ticket.Seat - 1] = false;
            }
            return seats;
        }
        internal void UpdateTickets()
        {
            foreach(Booking booking in bookings.ToArray())
            {
                if (!booking.IsActual())
                {
                    booking.Ticket.Status = TicketStatus.InStock;
                    bookings.Remove(booking);
                    AvailableTickets++;
                }
            }
        }
        internal List<Booking> bookings;
    }
    public class BoxOffice
    {
        public event PerformanceHandler PerformanceAdded;
        public event PerformanceHandler PerformanceDeleted;
        public BoxOffice()
        {
            InShow = new Dictionary<DateTime, List<PerformanceTickets>>();
        }
        public void AddInShow(Performance performance, Hall hall, DateTime dateTime, decimal price)
        {
            #region verify the conditions
            if (performance == null)
            {
                throw new ArgumentNullException("Performance cannot be null.", nameof(performance));
            }

            if (hall == null)
            {
                throw new ArgumentNullException("Hall cannot be null.", nameof(performance));
            }

            if (dateTime.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Unable to add tickets for a show on a past date", nameof(dateTime));
            }

            if(price < 0)
            {
                throw new ArgumentException("The ticket price cannot be negative", nameof(price));
            }
            #endregion
            DateTime date = dateTime.Date;
            List<Ticket> tickets = new List<Ticket>();
            int row = 0,
                seat = 1;
            for (int i = 1; i <= hall.QtyRows*hall.QtySeatsInRow; i++)
            {
                if (i % hall.QtySeatsInRow == 1)
                {
                    row++;
                    seat = 1;
                }
                tickets.Add(new Ticket(performance.Title, dateTime, price, row, seat));
                seat++;
            }
            if (InShow.ContainsKey(date))
            {
                InShow[date].Add(new PerformanceTickets(performance, hall, tickets, dateTime));
            }
            else
            {
                List<PerformanceTickets> performanceTickets = new List<PerformanceTickets>();
                performanceTickets.Add(new PerformanceTickets(performance, hall, tickets, dateTime));
                InShow.Add(date, performanceTickets);
            }
            if (PerformanceAdded != null)
            {
                PerformanceEventArgs args = new PerformanceEventArgs(performance, date);
                PerformanceAdded(this, args);
            }
        }
        public void DeleteInShow(Performance performance, DateTime date)
        {
            if (performance == null)
            {
                throw new ArgumentNullException("Performance cannot be null.", nameof(performance));
            }
            date = date.Date;
            if (InShow.ContainsKey(date))
            {
                InShow[date].RemoveAll(performances => performances.Performance.Equals(performance));
                if (InShow[date].Count == 0)
                {
                    InShow.Remove(date);
                }
            }
            if (PerformanceDeleted != null)
            {
                bool found = false;
                foreach (List<PerformanceTickets> performancesTickets in InShow.Values)
                {
                    foreach (PerformanceTickets performanceTickets in performancesTickets)
                    {
                        if (performanceTickets.DateTime.Date != date && performanceTickets.Performance.Equals(performance))
                        {
                            found = true;
                        }
                    }
                }
                if (!found)
                {
                    PerformanceEventArgs args = new PerformanceEventArgs(performance, date);
                    PerformanceDeleted(this, args);
                }
            }
        }
        public void DeleteInShow(DateTime date)
        {
            date = date.Date;
            if (InShow.ContainsKey(date))
            {
                InShow.Remove(date);
            }
        }
        public bool SellTicket(Performance performance, DateTime dateTime, int row, int seat)
        {
            #region verify the conditions
            if (performance == null)
            {
                throw new ArgumentNullException("Performance cannot be null.", nameof(performance));
            }

            if (row<1)
            {
                throw new ArgumentException("Seats are numbered starting from 1");
            }

            if (seat<1)
            {
                throw new ArgumentException("Row numbering starts from 1");
            }
            
            #endregion
            DateTime date = dateTime.Date;
            if (InShow.ContainsKey(date))
            {
                var crtPerfTickets = InShow[date].Find(performanceTickets => performanceTickets.Performance == performance && performanceTickets.DateTime == dateTime);
                if (crtPerfTickets != null && crtPerfTickets.AvailableTickets!=0)
                {
                    crtPerfTickets.UpdateTickets();
                    foreach (Ticket ticket in crtPerfTickets.Tickets)
                    {
                        if (ticket.Row == row && ticket.Seat == seat && ticket.DateTime == dateTime)
                            if (ticket.Status != TicketStatus.Sold && ticket.Status != TicketStatus.Booked)
                            {
                                ticket.Status = TicketStatus.Sold;
                                crtPerfTickets.AvailableTickets--;
                                return true;
                            }
                    }
                    return false;
                }
                else throw new NotFoundException("There are no tickets for this performance.");
            }
            else throw new NotFoundException("There are no performances on this date.");
        }
        public bool BookTicket(Performance performance, DateTime dateTime, int row, int seat, ClientInfo clientInfo)
        {
            #region verify the conditions
            if (performance == null)
            {
                throw new ArgumentNullException("Performance cannot be null.", nameof(performance));
            }

            if (clientInfo == null)
            {
                throw new ArgumentNullException("Person cannot be null.", nameof(performance));
            }

            if (row < 1)
            {
                throw new ArgumentException("Seats are numbered starting from 1");
            }

            if (seat < 1)
            {
                throw new ArgumentException("Row numbering starts from 1");
            }
            #endregion
            DateTime date = dateTime.Date;
            if (InShow.ContainsKey(date))
            {
                var crtPerfTickets = InShow[date].Find(performanceTickets => performanceTickets.Performance == performance && performanceTickets.DateTime == dateTime);
                if (crtPerfTickets != null && crtPerfTickets.AvailableTickets != 0)
                {
                    crtPerfTickets.UpdateTickets();
                    foreach (Ticket ticket in crtPerfTickets.Tickets)
                    {
                        if (ticket.Row == row && ticket.Seat == seat && ticket.DateTime == dateTime)
                            if (ticket.Status != TicketStatus.Sold && ticket.Status != TicketStatus.Booked)
                            {
                                ticket.Status = TicketStatus.Booked;
                                crtPerfTickets.bookings.Add(new Booking(clientInfo, ticket, 1));
                                crtPerfTickets.AvailableTickets--;
                                return true;
                            }
                    }
                    return false;
                }
                else throw new NotFoundException("There are no tickets for this performance.");
            }
            else throw new NotFoundException("There are no performances on this date.");
        }
        public bool SellReservation(ClientInfo clientInfo)
        {
            if(clientInfo == null)
            {
                throw new ArgumentNullException("Person cannot be null");
            }
            Booking booking;
            foreach(List<PerformanceTickets> performancesTickets in InShow.Values)
            {
                foreach(PerformanceTickets performanceTickets in performancesTickets)
                {
                    booking = performanceTickets.bookings.Find(crtBooking => crtBooking.ClientInfo.Equals(clientInfo));
                    if (booking != null)
                    {
                        performanceTickets.UpdateTickets();
                        booking.Ticket.Status = TicketStatus.Sold;
                        performanceTickets.bookings.Remove(booking);
                        return true;
                    }
                }
            }
            return false;
        }
        public Performance this[DateTime date, int index]
        {
            get
            {
                if (InShow.ContainsKey(date) && index < InShow[date].Count)
                {
                    return InShow[date.Date][index].Performance;
                }
                throw new IndexOutOfRangeException("One of the arguments is out of range.");
            }
        }
        public List<Performance> AvailablePerformances(DateTime date)
        {
            List<Performance> performances = new List<Performance>();
            if (InShow.TryGetValue(date, out List<PerformanceTickets> performancesTickets))
            {
                foreach (PerformanceTickets perfTickets in performancesTickets)
                {
                    performances.Add(perfTickets.Performance);
                }
            }
            return performances;
        }
        public List<DateTime> TimesPerformance(DateTime date, Performance performance)
        {
            if (performance == null)
            {
                throw new ArgumentNullException("Performance cannot be null.", nameof(performance));
            }
            List<DateTime> times = new List<DateTime>();
            if (InShow.TryGetValue(date, out List<PerformanceTickets> performancesTickets))
            {
                foreach (PerformanceTickets perfTickets in performancesTickets)
                {
                    if (perfTickets.Performance == performance&&perfTickets.DateTime>=DateTime.Now)
                    {
                        times.Add(perfTickets.DateTime);
                    }
                }
            }
            return times;
        }
        public bool[,] SeatsPerformance(DateTime dateTime, Performance performance)
        {
            if (performance == null)
            {
                throw new ArgumentNullException("Performance cannot be null.", nameof(performance));
            }
            DateTime date = dateTime.Date;
            if (InShow.TryGetValue(date, out List<PerformanceTickets> performancesTickets))
            {
                foreach (PerformanceTickets perfTickets in performancesTickets)
                {
                    if (perfTickets.Performance==performance && perfTickets.DateTime == dateTime)
                    {
                        return perfTickets.Seats(perfTickets.Hall.QtyRows, perfTickets.Hall.QtySeatsInRow);
                    }
                }
            }
            else throw new NotFoundException("There are no tickets for this performance.");
            return null;
        }
        
        private Dictionary<DateTime, List<PerformanceTickets>> InShow;
    }
}
