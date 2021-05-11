using System;
using System.Collections.Generic;

namespace BoxOfficeBL.Model
{
    public class PosterPerformances
    {
        public PosterPerformances()
        {
            posters = new List<Poster>();
        }
        public PosterPerformances(Poster[] posters) : this()
        {
            if (posters == null)
            {
                throw new ArgumentNullException("Posters cannot be null", nameof(posters));
            }
            foreach (Poster poster in posters)
            {
                AddPoster(poster);
            }
        }
        public PosterPerformances(List<Poster> posters) : this()
        {
            if (posters == null)
            {
                throw new ArgumentNullException("Posters cannot be null", nameof(posters));
            }
            foreach (Poster poster in posters)
            {
                AddPoster(poster);
            }
        }
        public IReadOnlyList<Poster> SearchForTitle(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException("Performance title cannot be null", nameof(title));
            }
            List<Poster> listPosters = new List<Poster>();
            foreach (Poster poster in posters)
            {
                if (poster.Performance.Title.ToLower() == title.ToLower())
                {
                    listPosters.Add(poster);
                }
            }
            return listPosters;
        }
        public IReadOnlyList<Poster> SearchForAuthor(string author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("The author name cannot be null", nameof(author));
            }
            List<Poster> listPosters = new List<Poster>();
            foreach (Poster poster in posters)
            {
                if (poster.Performance.Author.ToLower() == author.ToLower())
                {
                    listPosters.Add(poster);
                }
            }
            return listPosters;
        }
        public IReadOnlyList<Poster> SearchForGenre(string genre)
        {
            if (genre == null)
            {
                throw new ArgumentNullException("Performance genre cannot be null", nameof(genre));
            }
            List<Poster> listPosters = new List<Poster>();
            foreach (Poster poster in posters)
            {
                if (poster.Performance.Genre.ToLower() == genre.ToLower())
                {
                    listPosters.Add(poster);
                }
            }
            return listPosters;
        }
        public IReadOnlyList<Poster> SearchForYear(int year)
        {
            if (year < 0)
            {
                throw new ArgumentException("The year cannot be negative", nameof(year));
            }
            List<Poster> listPosters = new List<Poster>();
            foreach (Poster poster in posters)
            {
                if (poster.Performance.Year == year)
                {
                    listPosters.Add(poster);
                }
            }
            return listPosters;
        }
        public bool AddPoster(Poster poster)
        {
            if (poster == null)
            {
                throw new ArgumentNullException("Poster cannot be null", nameof(poster));
            }
            foreach (Poster post in posters)
            {
                if (post.Equals(poster))
                {
                    return false;
                }
            }
            posters.Add(poster);
            return true;
        }
        public bool DeletePoster(Poster poster)
        {

            if (poster == null)
            {
                throw new ArgumentNullException("Poster cannot be null", nameof(poster));
            }
            if (posters.Count > 0)
            {
                posters.Remove(poster);
                return true;
            }
            return false;
        }
        public void Clear()
        {
            posters.Clear();
        }
        public IReadOnlyList<Poster> Posters
        {
            get
            {
                return posters;
            }
        }
        private List<Poster> posters;
    }
}
