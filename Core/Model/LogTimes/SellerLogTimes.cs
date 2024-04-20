using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Validations;
using Baghel.TIP.Core.Utils;
using System.Collections.Generic;

namespace Baghel.TIP.Core.Model.LogTimes
{
    /// <summary>
    /// Allows the seller to send to the buyer the log times information. No Request from buyer is required.
    /// </summary>
    public class SellerLogTimes : Common.ModelBase
    {
        
        private readonly IValidate<SellerLogTimes> validate;

        public SellerLogTimes()
        {
            this.validate = Factory.CreateValidation();
        }
        public SellerLogTimes(IValidate<SellerLogTimes> validate)
        {
            this.validate = validate;
        }
        public TransactionHeader TransactionHeader { get; set; }
        /// <summary>
        /// String that indicates additional information the seller can send to the buyer
        /// </summary>
        public string ExternalComment { get; set; }
        /// <summary>
        /// Array of MediaOutlet objects  
        /// </summary>
        public List<MediaOutlet> MediaOutlets { get; set; }
        /// <summary>
        /// Units listed in the API units can be defined by the system that is creating the API. 
        /// </summary>
        public List<Unit> Units { get; set; }

       

      

        public virtual void Validate()
        {
            validate.Validate(this);
        }
    }
}
