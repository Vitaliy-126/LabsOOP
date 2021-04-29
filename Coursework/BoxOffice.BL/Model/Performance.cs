namespace BoxOfficeBL
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
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"Название: \"{Title}\"({Year}). Автор: {Author}. Жанр: {Genre}. ";
        }
        public string Author { get; }
        public string Title { get; }
        public string Genre { get; }
        public int Year { get; }
    }
}
