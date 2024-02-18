using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
namespace Baghel.TIP.Core.Validations
{
    public class ValidateSellerLogTimes : ValidationLinker
    {
        public ValidateSellerLogTimes(IValidate<Model.Common.Model> validate) : base(validate)
        {
        }

        public override void Validate(Model.Common.Model model)
        {
            base.Validate(model);
            var sellerLogTimes = (SellerLogTimes)model;
            if (sellerLogTimes.MediaOutlets == null)
                model.Error.ErrorList.Add("mediaOutlets", "mediaOutlets cannot be empty");
            else
            {
                if (sellerLogTimes.MediaOutlets.Count == 0) model.Error.ErrorList.Add("mediaOutlets", "mediaOutlets cannot be empty");
                else
                {
                    foreach (var mediaOutlet in sellerLogTimes.MediaOutlets)
                    {
                        if (mediaOutlet.MediaOutletIds == null) model.Error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletIds{0}", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet)), string.Format("mediaOutlet.MediaOutletIds{0} cannot be empty", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet)));
                        else
                        {
                            if (mediaOutlet.MediaOutletIds.Count == 0) model.Error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletIds{0}", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet)), string.Format("mediaOutlet.MediaOutletIds{0} cannot be empty", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet)));
                            else
                            {
                                foreach (var ids in mediaOutlet.MediaOutletIds)
                                {
                                    if (string.IsNullOrEmpty(ids.Id)) model.Error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletIds{0}Ids{1}", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet), mediaOutlet.MediaOutletIds.IndexOf(ids)), string.Format("mediaOutlet.MediaOutletIds{0}Ids{1} cannot be empty", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet), mediaOutlet.MediaOutletIds.IndexOf(ids)));
                                    if (string.IsNullOrEmpty(ids.SrcName)) model.Error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletIds{0}SrcName{1}", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet), mediaOutlet.MediaOutletIds.IndexOf(ids)), string.Format("mediaOutlet.MediaOutletIds{0}SrcName{1} cannot be empty", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet), mediaOutlet.MediaOutletIds.IndexOf(ids)));

                                }
                                if (string.IsNullOrEmpty(mediaOutlet.MediaOutletName)) model.Error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletName{0}", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet)), string.Format("mediaOutlet.MediaOutletName{0} cannot be empty", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet)));
                                if (string.IsNullOrEmpty(mediaOutlet.MediaoutletType)) model.Error.ErrorList.Add(string.Format("mediaOutlet.MediaoutletType{0}", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet)), string.Format("mediaOutlet.MediaoutletType{0} cannot be empty", sellerLogTimes.MediaOutlets.IndexOf(mediaOutlet)));
                            }
                        }
                    }
                }
            }
            if (sellerLogTimes.Units == null) model.Error.ErrorList.Add("units", "units cannot be empty");
        }

    }
}
