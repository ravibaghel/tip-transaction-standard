using Baghel.TIP.Core.Model.Common;

namespace Baghel.TIP.Core.Model.LogTimes
{
    /// <summary>
    /// Child unit details for footprint unit to support Audience Network, Diginet or other forms of "child" units
    /// </summary>
    public struct ChildUnit
    {
        /// <summary>
        /// Seller generated identifier for the child spot; conditional when there is a 'parent' unit is sold as a footprint 
        /// </summary>
        public string UnitId { get; set; }
        public SalesElementHeader SalesElementHeader { get; set; }
        /// <summary>
        /// Gross unit rate 
        /// </summary>
        public float Rate { get; set; }
        /// <summary>
        /// Array of identifier objects containing the creative information; at  least one identifier object must be provided if spot status is equal to 'Aired' or 'Finalized'
        /// </summary>
        public Creative Creative { get; set; }
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Required if the child's unit is equal to "Aired" 
        /// </summary>
        public Common.DateTime DateTime { get; set; }
    }
}