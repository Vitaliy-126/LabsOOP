namespace BoxOffice
{
    public class Performance
    {
        public Performance(string author, string title, string genre, int year)
        {
            Author = author;
            Title = title;
            Genre = genre;
            Year = year;
        }
        public static bool operator == (in Performance left, in Performance rigth)
        {
            if (left.Author == rigth.Author && left.Title == rigth.Title && left.Genre == rigth.Genre && left.Year == rigth.Year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(in Performance left, in Performance rigth)
        {
            if (left.Author == rigth.Author || left.Title == rigth.Title || left.Genre == rigth.Genre || left.Year == rigth.Year)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Author { get; }
        public string Title { get; }
        public string Genre { get; }
        public int Year { get; }
    }
}
