using System.Collections.Generic;

namespace BoxOffice
{
    public class BoxOffice
    {
        private Dictionary<Performance, List<Ticket>> InShow;

        public void AddInShow(Performance performance, int quantityTickets)
        {
            List<Ticket> tickets = null;
            InShow.Add(performance, tickets);
        }

        public void DeleteInShow()
        {

        }
        //Performance[] Sessions()
        //{

        //}
        void SellTicket(Performance performance)
        {
            if (InShow != null) {
                for (int i = 0; i < InShow.Count; i++)
                {
                    if(performance==InShow.Keys)
                }
            }
        }
    }
}
