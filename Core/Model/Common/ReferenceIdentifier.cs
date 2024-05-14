using System;

namespace Baghel.TIP.Core.Model.Common
{
    /// <summary>
    /// Reference details for RFP, Proposal, Order and Invoice 
    /// </summary>
    public class ReferenceIdentifier
    {
        private string _referenceSourceName;
        private string _referenceSourceId;
        private ReferenceType _referenceType;
        private string _referenceId;
        /// <summary>
        /// Name associated with the organization that is supplying the ids and version information
        /// </summary>
        public string ReferenceSourceName
        {
            get { return _referenceSourceName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ReferenceSourceName cannot be null or empty.");
                }
                _referenceSourceName = value;
            }
        }
        /// <summary>
        /// ID associated with the organization sending the information
        /// </summary>
        public string ReferenceSourceId
        {
            get { return _referenceSourceId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ReferenceSourceId cannot be null or empty.");
                }
                _referenceSourceId = value;
            }
        }
        /// <summary>
        /// Reference source look up such as a URI to lookup information about the reference source name
        /// </summary>
        public string ReferenceSourceLookup { get; set; }
        /// <summary>
        /// Indicates the type of data that is being provided
        /// </summary>
        public ReferenceType ReferenceType
        {
            get { return _referenceType; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("ReferenceType cannot be zero.");
                }
                _referenceType = value;
            }
        }
        /// <summary>
        /// Indicates the number or string ID associated with the reference type
        /// </summary>
        public string ReferenceId
        {
            get { return _referenceId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ReferenceId cannot be null or empty.");
                }
                _referenceId = value;
            }
        }
        /// <summary>
        /// Version number associated with the reference id; this is used to track to track changes
        /// </summary>
        public string ReferenceVersionId { get; set; }
        /// <summary>
        /// Free form name used to further identify the type of entity such as the name associated to the RFP, Order, Proposal, or other types of references
        /// </summary>
        public string ReferenceName { get; set; }

    }
}
