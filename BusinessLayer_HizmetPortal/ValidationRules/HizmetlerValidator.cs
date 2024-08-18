using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class HizmetlerValidator : AbstractValidator<Hizmetler>
    {
        public HizmetlerValidator() 
        {
            RuleFor(x => x.HizmetName).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.HizmetDescription).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.HizmetImage).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.HizmetIcon).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.HizmetName).MinimumLength(10).WithMessage("En az 10 karakter gir");
            RuleFor(x => x.HizmetDescription).MinimumLength(20).WithMessage("En az 20 karakter gir");
            RuleFor(x => x.HizmetName).MaximumLength(100).WithMessage("En çok 100 karakter girebilirsin");
            RuleFor(x => x.HizmetDescription).MaximumLength(1000).WithMessage("En çok 1000 karakter girebilirsin");
        }
    }
}
