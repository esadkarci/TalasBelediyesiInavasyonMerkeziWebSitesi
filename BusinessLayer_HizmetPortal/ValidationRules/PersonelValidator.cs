using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class PersonelValidator : AbstractValidator<Personel>
    {
        public PersonelValidator() 
        {
            RuleFor(x => x.PersonelIsim).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.PersonelSoyisim).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.PersonelUnvan).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.PersonelImage).NotEmpty().WithMessage("Boş geçme");
            RuleFor(x => x.PersonelCV).NotEmpty().WithMessage("Boş geçme");

            RuleFor(x => x.PersonelIsim).MinimumLength(3).WithMessage("En az 3 karakter gir");
            RuleFor(x => x.PersonelSoyisim).MinimumLength(2).WithMessage("En az 2 karakter gir");
            RuleFor(x => x.PersonelUnvan).MinimumLength(5).WithMessage("En az 5 karakter gir");
            RuleFor(x => x.PersonelCV).MinimumLength(20).WithMessage("En az 20 karakter gir");

            RuleFor(x => x.PersonelIsim).MaximumLength(30).WithMessage("En çok 30 karakter girebilirsin");
            RuleFor(x => x.PersonelSoyisim).MaximumLength(30).WithMessage("En çok 30 karakter girebilirsin");
            RuleFor(x => x.PersonelUnvan).MaximumLength(30).WithMessage("En çok 30 karakter girebilirsin");
            RuleFor(x => x.PersonelCV).MaximumLength(7600).WithMessage("En çok 7600 karakter girebilirsin");
        }
    }
}
