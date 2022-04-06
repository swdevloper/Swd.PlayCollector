using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollectory.Business.Model
{
    public class CollectionItemValidator: AbstractValidator<CollectionItem>
    {
        public CollectionItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Darf nicht leer sein!");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Darf nicht leer sein!");
            RuleFor(x => x.Number).MinimumLength(3).WithMessage("Darf nicht leer sein!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Darf nicht länger als 50 Zeichen sein!");
            
        }


    }
}
