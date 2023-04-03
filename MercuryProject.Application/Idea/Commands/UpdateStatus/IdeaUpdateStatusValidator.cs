using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MercuryProject.Application.Idea.Commands.Approve;

namespace MercuryProject.Application.Idea.Approve
{
    public class IdeaUpdateStatusValidator : AbstractValidator<IdeaUpdateStatusCommand>
    {
        public IdeaUpdateStatusValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
        }
    }
}
