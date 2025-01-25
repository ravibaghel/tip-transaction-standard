using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Broadcast date and broadcast time used in Logtimes & Invoices
    /// </summary>
    public class DateTime
    {
        private System.DateTime? _broadcastDate;
        private System.DateTime? _calendarDateTime;
        /// <summary>
        /// Broadcast date on which the unit aired/scheduled; this is not a calendar date
        /// </summary>
        public System.DateTime? BroadcastDate
        {
            get { return _broadcastDate; }
            set
            {
               
                _broadcastDate = value;
            }
        }
        public System.DateTime? CalendarDateTime
        {
            get { return _calendarDateTime; }
            set
            {
                if (value.HasValue && value.Value.Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException("CalendarDateTime must be in UTC.");
                }
                _calendarDateTime = value;
            }
        }
    }
}
