using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddPerfomance(in Performance performance)
        {
            Performance[] tempPerformances = new Performance[performances.Length+1];
            for(int i = 0; i < performances.Length; i++)
            {
                tempPerformances[i] = performances[i];
            }
            tempPerformances[tempPerformances.Length - 1] = performance;
            performances = tempPerformances;
        }

        public void DeletePerfomance(string title)
        {
            if (SearchForTitle(title, out int index) != null)
            {
                Performance[] tempPerformances = new Performance[performances.Length - 1];
                for (int i = 0; i < performances.Length; i++)
                {
                    if (i != index)
                    {
                        tempPerformances[i] = performances[i];
                    }
                }
                performances = tempPerformances;
            }
        }

        private Performance[] performances;
    }
}
