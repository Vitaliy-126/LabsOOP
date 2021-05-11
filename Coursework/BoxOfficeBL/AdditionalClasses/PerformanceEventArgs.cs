using System;
using BoxOfficeBL.Model;

namespace BoxOfficeBL.AdditionalClasses
{
    public delegate void PerformanceHandler(object sender, PerformanceEventArgs args);
    public class PerformanceEventArgs
    {
        public Performance Performance { get; }
        public DateTime Date { get; }
        public PerformanceEventArgs(Performance performance, DateTime date)
        {
            Performance = performance;
            Date = date.Date;
        }
    }
}
