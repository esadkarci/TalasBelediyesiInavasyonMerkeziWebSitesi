using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class ServiceValidation:AbstractValidator<Service>
    {
        
        public ServiceValidation()
        {
            RuleFor(x => x.ServiceTitle).NotEmpty().WithMessage("boş geçme");
            RuleFor(x => x.ServiceDescription).NotEmpty().WithMessage("boş geçme");
            RuleFor(x => x.ServiceTitle).MinimumLength(3).WithMessage("boş geçme");
        }
    }
}
