using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Valid days of week
    /// </summary>
    public struct DayOfWeek
    {
        public bool IsMonday { get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get;set; }
        public bool IsFriday { get; set; }
        public bool IsSaturday { get;set; }
        public bool IsSunday { get;set; }

    }
}
