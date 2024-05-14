using Baghel.TIP.Core.Model.Common;
using System;

namespace Baghel.TIP.Core.Model.LogTimes
{
    /// <summary>
    /// Child unit details for footprint unit to support Audience Network, Diginet or other forms of "child" units
    /// </summary>
    public class ChildUnit
    {
        private string _unitId;
        private SalesElementHeader _salesElementHeader;
        private float? _rate;
        /// <summary>
        /// Seller generated identifier for the child spot; conditional when there is a 'parent' unit is sold as a footprint 
        /// </summary>
        public string UnitId
        {
            get { return _unitId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("UnitId cannot be null or empty.");
                }
                _unitId = value;
            }
        }
        public SalesElementHeader SalesElementHeader
        {
            get { return _salesElementHeader; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("SalesElementHeader cannot be null.");
                }
                _salesElementHeader = value;
            }
        }
        /// <summary>
        /// Gross unit rate 
        /// </summary>
        public float? Rate
        {
            get { return _rate; }
            set
            {
                if (value.HasValue && value < 0)
                {
                    throw new ArgumentException("Rate cannot be negative.");
                }
                _rate = value;
            }
        }
        /// <summary>
        /// Array of identifier objects containing the creative information; at  least one identifier object must be provided if spot status is equal to 'Aired' or 'Finalized'
        /// </summary>
        public Creative Creative { get; set; }
        public Status? Status { get; set; }
        /// <summary>
        /// Required if the child's unit is equal to "Aired" 
        /// </summary>
        public Common.DateTime DateTime { get; set; }
    }

    public enum Status
    {
        Aired,
        Scheduled,
        NoRun,
        Finalized,
        NotScheduled,
        Preempted
    }
}