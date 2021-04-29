using System.Collections.Generic;

namespace BoxOfficeBL
{
    public class PosterPerformances
    {
        public PosterPerformances()
        {
            performances = new List<Performance>();
        }
        public PosterPerformances(Performance[] performances) : this()
        {
            foreach(Performance performance in performances)
            {
                this.performances.Add(performance);
            }
        }
        public PosterPerformances(List<Performance> performances) : this()
        {
            foreach (Performance performance in performances)
            {
                this.performances.Add(performance);
            }
        }
        public Performance SearchForAuthor(string author)
        {
            for (int i = 0; i < performances.Count; i++)
            {
                if (performances[i].Author == author)
                {
                    return performances[i];
                }
            }
            return null;
        }
        public Performance SearchForTitle(string title)
        {
            for (int i = 0; i < performances.Count; i++)
            {
                if (performances[i].Author == title)
                {
                    return performances[i];
                }
            }
            return null;
        }
        public Performance SearchForGenre(string genre)
        {
            for (int i = 0; i < performances.Count; i++)
            {
                if (performances[i].Genre == genre)
                {
                    return performances[i];
                }
            }
            return null;
        }
        public Performance SearchForYear(int year)
        {
            for (int i = 0; i < performances.Count; i++)
            {
                if (performances[i].Year == year)
                {
                    return performances[i];
                }
            }
            return null;
        }
        public void AddPerformance(in Performance performance)
        {
            performances.Add(performance);
        }
        public void DeletePerformance(in Performance performance)
        {
            if (performances.Count > 0)
            {
                if (performances.Remove(performance))
                {
                    throw new NotFoundException();
                }
            }
        }
        public Performance this[int index]
        {
            get
            {
                return performances[index];
            }
        }
        private List<Performance> performances;
    }
}

