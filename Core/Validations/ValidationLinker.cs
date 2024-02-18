using Baghel.TIP.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baghel.TIP.Core.Validations
{
    public class ValidationLinker : IValidate<Model.Common.Model>
    {
        private readonly IValidate<Model.Common.Model> _validator;

        public ValidationLinker(IValidate<Model.Common.Model> validate)
        {
            _validator = validate;
        }

        public virtual void Validate(Model.Common.Model model)
        {

            _validator.Validate(model);
        }
    }
}
