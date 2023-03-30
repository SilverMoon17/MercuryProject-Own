using FluentValidation;
using MercuryProject.Application.Authentication.Queries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Application.Product.Queries.GetProductById
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Specify the id!");
        }
    }
}
