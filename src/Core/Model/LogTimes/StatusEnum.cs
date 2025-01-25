using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.LogTimes
{
    public enum StatusEnum { Aired, Scheduled, [EnumMember(Value = "No Run")] NoRun, Finalized, [EnumMember(Value = "Not Scheduled")] NotScheduled, Preempted }
}
