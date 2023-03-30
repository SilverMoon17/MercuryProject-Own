using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MercuryProject.Application.Product.Commands.Delete
{
    public class ProductDeleteCommandValidator : AbstractValidator<ProductDeleteCommand>
    {
        public ProductDeleteCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Specify the id");
        }
    }
}
