using System;

namespace BoxOfficeBL.Model
{
    public class Poster
    {
        public Performance Performance { get; }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Description cannot be empty or null", nameof(value));
                }
                else
                {
                    description = value;
                }
            }
        }
        public DateTime StartDate { get; }
        public Poster(Performance performance, DateTime startDate)
        {
            #region verify the conditions
            if (performance == null)
            {
                throw new ArgumentNullException("Performance cannot be null.", nameof(performance));
            }

            if (startDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Start date cannot be less than current", nameof(startDate));
            }
            #endregion
            Performance = performance;
            StartDate = startDate.Date;
            Description = "No description";
        }
        public override string ToString()
        {
            return Performance.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is Poster && obj != null)
            {
                Poster poster = (Poster)obj;
                return Performance.Equals(poster.Performance);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Performance.GetHashCode();
        }
        private string description;
    }
}
