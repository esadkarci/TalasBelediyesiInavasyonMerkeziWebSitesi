using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.ValidationRules
{
    public class GaleriValidator : AbstractValidator<Galeri>
    {
        public GaleriValidator()
        {

            RuleFor(x => x.GaleriImage).NotEmpty().WithMessage("Boş geçme");
        }
    }
}
