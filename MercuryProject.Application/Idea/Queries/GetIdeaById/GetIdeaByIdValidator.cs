using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MercuryProject.Application.Idea.Queries.GetIdeaById
{
    public class GetIdeaByIdValidator : AbstractValidator<GetIdeaByIdQuery>
    {
        public GetIdeaByIdValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
        }
    }
}
