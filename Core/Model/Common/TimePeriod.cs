using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Combines date window, DOW and time window objects
    /// </summary>
    public struct TimePeriod
    {
        public DateWindow DateWindow { get; set; }
        public DayOfWeek DOW { get; set; }
        public TimeWindow TimeWindow { get; set; }
    }
}
