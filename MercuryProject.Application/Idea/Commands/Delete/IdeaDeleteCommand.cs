using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Application.Idea.Commands.Delete
{
    public record IdeaDeleteCommand(string Id) : IRequest<ErrorOr<bool>>;
}
