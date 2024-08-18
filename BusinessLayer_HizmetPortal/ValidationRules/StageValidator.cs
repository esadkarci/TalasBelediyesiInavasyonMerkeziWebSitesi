using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class StageValidator : AbstractValidator<Stage>
    {
        public StageValidator() 
        {
            RuleFor(x => x.StageName).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.StageName).MinimumLength(2).WithMessage("En az 2 karakter gir");
            RuleFor(x => x.StageName).MaximumLength(20).WithMessage("En çok 20 karakter girebilirsin");
        }
    }
}
