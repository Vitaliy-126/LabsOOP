using System;

namespace BoxOfficeBL.Model
{
    public class Performance
    {
        public string Title { get; }
        public string Author { get; }
        public string Genre { get; }
        public int Year { get; }
        public Performance(string title, string author, string genre, int year)
        {
            #region verify the conditions
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Performance title cannot be empty or null", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException("The author name cannot be empty or null", nameof(author));
            }

            if (string.IsNullOrWhiteSpace(genre))
            {
                throw new ArgumentNullException("Performance genre cannot be empty or null", nameof(genre));
            }

            if (year < 0)
            {
                throw new ArgumentException("The year cannot be negative", nameof(year));
            }
            #endregion
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }
        public override bool Equals(object obj)
        {
            if (obj is Performance && obj != null)
            {
                Performance performance = (Performance)obj;
                return Title == performance.Title && Author == performance.Author && Genre == performance.Genre && Year == performance.Year;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
        public override string ToString()
        {
            return $"Title: \"{Title}\"({Year}). Author: {Author}. Genre: {Genre}. ";
        }
    }
}
