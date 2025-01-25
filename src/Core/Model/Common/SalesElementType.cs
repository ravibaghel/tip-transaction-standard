using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    public enum SalesElementType
    {

        [EnumMember(Value = "Time-specific")] Timespecific, Program, Audience, Package
    } 
}
