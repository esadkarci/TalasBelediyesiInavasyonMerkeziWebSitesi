using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class HaberlerValidator : AbstractValidator<Haberler>
    {
        public HaberlerValidator() 
        {
            RuleFor(x => x.HaberTitle).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.HaberDescription).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.HaberDate).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.HaberImage).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.HaberTitle).MinimumLength(10).WithMessage("En az 10 karakter gir");
            RuleFor(x => x.HaberDescription).MinimumLength(20).WithMessage("En az 20 karakter gir");
            RuleFor(x => x.HaberTitle).MaximumLength(150).WithMessage("En çok 150 karakter girebilirsin");
            RuleFor(x => x.HaberDescription).MaximumLength(2500).WithMessage("En çok 2500 karakter girebilirsin");
        }
    }
}
