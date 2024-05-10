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
        /// <summary>
        /// Broadcast date on which the unit aired/scheduled; this is not a calendar date
        /// </summary>
        public System.DateTime BroadcastDate { get; set; }
        public System.DateTime CalendarDateTime { get; set; }
    }
}
