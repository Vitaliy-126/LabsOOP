namespace BoxOffice
{
    public class BoxOfficeController
    {

        public BoxOfficeController(BoxOffice boxOffice)
        {
            CurrentBoxOffice = boxOffice;
        }

        public void AddInShow(Performance performance, int quantityTickets)
        {

        }

        public void DeleteInShow()
        {

        }

        private BoxOffice CurrentBoxOffice;
        private int QuantityTickets;
    }
}
