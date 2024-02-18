namespace Baghel.TIP.Core.Model.Common
{
    public abstract class Model
    {
        /// <summary>
        /// 
        /// </summary>
        public TransactionHeader TransactionHeader { get; set; }
        public Error Error { get; set; }
    }
}