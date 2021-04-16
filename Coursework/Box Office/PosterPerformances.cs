namespace BoxOffice
{
    public class PosterPerformances
    {
        public Performance SearchForAuthor(string author)
        {
            for(int i = 0; i < performances.Length; i++)
            {
                if (performances[i].Author == author)
                {
                    return performances[i];
                }
            }
            return null;
        }
        public Performance SearchForTitle(string title,out int index)
        {
            for (int i = 0; i < performances.Length; i++)
            {
                if (performances[i].Author == title)
                {
                    index = i;
                    return performances[i];
                }
            }
            index = -1;
            return null;
        }
        public Performance SearchForGenre(string genre)
        {
            for (int i = 0; i < performances.Length; i++)
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
            for (int i = 0; i < performances.Length; i++)
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
            if (performances == null)
            {
                performances = new Performance[] { performance };
            }
            else
            {
                Performance[] tempPerformances = new Performance[performances.Length + 1];
                for (int i = 0; i < performances.Length; i++)
                {
                    tempPerformances[i] = performances[i];
                }
                tempPerformances[tempPerformances.Length - 1] = performance;
                performances = tempPerformances;
            }
        }
        public void DeletePerformance(string title)
        {
            if (SearchForTitle(title, out int index) != null)
            {
                Performance[] tempPerformances = new Performance[performances.Length - 1];
                int correction = 0; 
                for (int i = 0; i < performances.Length; i++)
                {
                    if (i != index)
                    {
                        tempPerformances[i - correction] = performances[i];
                    }
                    else
                    {
                        correction++;
                    }
                }
                performances = tempPerformances;
            }
        }
        public Performance this[int index]
        {
            get
            {
                return performances[index];
            }
        }
        private Performance[] performances;
    }
}
