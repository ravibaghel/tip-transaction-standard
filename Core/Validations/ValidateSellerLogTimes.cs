using Baghel.TIP.Core.Model.Common;
using Baghel.TIP.Core.Model.LogTimes;
namespace Baghel.TIP.Core.Validations
{
    internal class ValidateSellerLogTimes : CommonValidations,IValidate<SellerLogTimes>
    {
        public void Validate(SellerLogTimes model)
        {
            var error = new Error
            {
                ErrorList = new Dictionary<string, string>()
            };
            Validate(model, error);
            if (model.MediaOutlets == null)
                error.ErrorList.Add("mediaOutlets", "mediaOutlets cannot be empty");
            else
            {
                if (model.MediaOutlets.Count == 0) error.ErrorList.Add("mediaOutlets", "mediaOutlets cannot be empty");
                else {
                    foreach (var mediaOutlet in model.MediaOutlets) {
                        if (mediaOutlet.MediaOutletIds == null) error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletIds{0}",model.MediaOutlets.IndexOf(mediaOutlet)), string.Format("mediaOutlet.MediaOutletIds{0} cannot be empty", model.MediaOutlets.IndexOf(mediaOutlet)));
                        else {
                            if (mediaOutlet.MediaOutletIds.Count==0) error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletIds{0}", model.MediaOutlets.IndexOf(mediaOutlet)), string.Format("mediaOutlet.MediaOutletIds{0} cannot be empty", model.MediaOutlets.IndexOf(mediaOutlet)));
                            else
                            {
                                foreach (var ids in mediaOutlet.MediaOutletIds)
                                {
                                    if(string.IsNullOrEmpty(ids.Id)) error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletIds{0}Ids{1}", model.MediaOutlets.IndexOf(mediaOutlet),mediaOutlet.MediaOutletIds.IndexOf(ids)), string.Format("mediaOutlet.MediaOutletIds{0}Ids{1} cannot be empty", model.MediaOutlets.IndexOf(mediaOutlet),mediaOutlet.MediaOutletIds.IndexOf(ids)));
                                    if (string.IsNullOrEmpty(ids.SrcName)) error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletIds{0}SrcName{1}", model.MediaOutlets.IndexOf(mediaOutlet), mediaOutlet.MediaOutletIds.IndexOf(ids)), string.Format("mediaOutlet.MediaOutletIds{0}SrcName{1} cannot be empty", model.MediaOutlets.IndexOf(mediaOutlet), mediaOutlet.MediaOutletIds.IndexOf(ids)));
                                    
                                }
                                if (string.IsNullOrEmpty(mediaOutlet.MediaOutletName)) error.ErrorList.Add(string.Format("mediaOutlet.MediaOutletName{0}", model.MediaOutlets.IndexOf(mediaOutlet)), string.Format("mediaOutlet.MediaOutletName{0} cannot be empty", model.MediaOutlets.IndexOf(mediaOutlet)));
                                if (string.IsNullOrEmpty(mediaOutlet.MediaoutletType)) error.ErrorList.Add(string.Format("mediaOutlet.MediaoutletType{0}", model.MediaOutlets.IndexOf(mediaOutlet)), string.Format("mediaOutlet.MediaoutletType{0} cannot be empty", model.MediaOutlets.IndexOf(mediaOutlet)));
                            }
                        }
                    }
                }
            }
            if (model.Units == null) error.ErrorList.Add("units", "units cannot be empty");
            model.Response = error;
            
        }
    }
}
