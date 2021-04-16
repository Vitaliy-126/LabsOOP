using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Author { get; }
        public string Title { get; }
        public string Genre { get; }
        public int Year { get; }
    }
}
