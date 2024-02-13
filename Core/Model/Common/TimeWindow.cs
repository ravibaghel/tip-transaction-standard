using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    public struct TimeWindow
    {
        /// <summary>
        /// Start time, indicates the starting time for the period. Time is considered local to the mediaoutlet. Using military time HH:MM:SS
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// End time, indicates the ending time for the period. Time is interpreted based on the local timezone of the mediaoutlet. Using military time HH:MM:SS
        /// </summary>
        public string EndTime { get; set; }
    }
}
