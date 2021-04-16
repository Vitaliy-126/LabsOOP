using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
    class PerformanceController
    {
        public int QuantityTickets { get; }
        public Performance CurrentPerformance { get; }
        public bool IsNew { get; } = false;
    }
}
