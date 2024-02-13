using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Object representing the creative
    /// </summary>
    public class Creative
    {
        public enum StatusEnum{ [EnumMember(Value = "Not Final")]NotFinal, Final, [EnumMember(Value ="On-Hand")]OnHand }
        /// <summary>
        /// UniqueID from the seller of the Creative [who assigns this in the process]
        /// </summary>
        public List<Identifier> Ids { get; set; }
        /// <summary>
        /// Name of the creative
        /// </summary>
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Length (in seconds) of the Creative excluding slate
        /// </summary>
        public int Length { get; set; }

    }
}
