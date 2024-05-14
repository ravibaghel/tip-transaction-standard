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
    public class TimePeriod
    {
        private DateWindow _dateWindow;
        private DayOfWeek _dow;
        public DateWindow DateWindow
        {
            get { return _dateWindow; }
            set
            {
                if (value is null)
                {
                    throw new ArgumentException("DateWindow cannot be null.");
                }
                _dateWindow = value;
            }
        }
        public DayOfWeek DOW
        {
            get { return _dow; }
            set
            {
                if (!Enum.IsDefined(typeof(DayOfWeek), value))
                {
                    throw new ArgumentException("Invalid DayOfWeek.");
                }
                _dow = value;
            }
        }
        public TimeWindow TimeWindow { get; set; }
    }
}
