using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator() 
        {
            RuleFor(x => x.ProjectTitle).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.ProjectDescription).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.ProjectImage).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.StageId).NotEmpty().WithMessage("Boş geçme");

            RuleFor(x => x.ProjectTitle).MinimumLength(5).WithMessage("En az 5 karakter gir");
            RuleFor(x => x.ProjectDescription).MinimumLength(10).WithMessage("En az 10 karakter gir");

            RuleFor(x => x.ProjectTitle).MaximumLength(100).WithMessage("En çok 100 karakter girebilirsin");
            RuleFor(x => x.ProjectDescription).MaximumLength(1000).WithMessage("En çok 1000 karakter girebilirsin");
        }
    }
}
