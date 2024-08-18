using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class DuyurularValidator : AbstractValidator<Duyurular>
    {
        public DuyurularValidator() 
        {
            RuleFor(x => x.DuyurularImage).NotEmpty().WithMessage("Boş geçme");
        }
    }
}
