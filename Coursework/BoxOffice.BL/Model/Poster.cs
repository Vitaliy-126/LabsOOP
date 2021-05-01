using System;

namespace BoxOfficeBL
{
    public class Poster : Performance
    {
        public string Description { get; }
        public DateTime StartDate { get; }
        public Poster(string title, string author, string genre, int year, string description, DateTime startDate) : base(title,author,genre,year)
        {
            Description = description;
            StartDate = startDate;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" +
                   $"У театрах с: {StartDate.ToString("dd MMMM")}\n" +
                   $"Описание: {Description}";
        }
    }
}
