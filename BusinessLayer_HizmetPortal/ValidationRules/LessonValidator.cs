using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class LessonValidator:AbstractValidator<Lesson>
    {
        public LessonValidator() 
        {
            RuleFor(x => x.LessonTitle).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.LessonDescription).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.LessonImage).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.LessonTitle).MinimumLength(10).WithMessage("En az 10 karakter gir");
            RuleFor(x => x.LessonDescription).MinimumLength(20).WithMessage("En az 20 karakter gir");
            RuleFor(x => x.LessonTitle).MaximumLength(100).WithMessage("En çok 100 karakter girebilirsin");
            RuleFor(x => x.LessonDescription).MaximumLength(1000).WithMessage("En çok 1000 karakter girebilirsin");
        }
    }
}
