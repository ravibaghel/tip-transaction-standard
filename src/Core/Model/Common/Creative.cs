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
        private List<Identifier> _ids;
        private int? _length;
        //public enum StatusEnum{ [EnumMember(Value = "Not Final")]NotFinal, Final, [EnumMember(Value ="On-Hand")]OnHand }
        /// <summary>
        /// UniqueID from the seller of the Creative [who assigns this in the process]
        /// </summary>
        public List<Identifier> Ids
        {
            get { return _ids; }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("Ids cannot be null or empty.");
                }
                _ids = value;
            }
        }
        /// <summary>
        /// Name of the creative
        /// </summary>
        public string Name { get; set; }
        public Status? Status { get; set; }
        /// <summary>
        /// Length (in seconds) of the Creative excluding slate
        /// </summary>
        public int? Length
        {
            get { return _length; }
            set
            {
                if (value.HasValue && value < 0)
                {
                    throw new ArgumentException("Length cannot be negative.");
                }
                _length = value;
            }
        }

    }

    public enum Status
    {
        NotFinal,
        Final,
        OnHand
    }
}
