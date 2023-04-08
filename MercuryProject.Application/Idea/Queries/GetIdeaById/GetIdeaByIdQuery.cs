using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MercuryProject.Application.Idea.Common;

namespace MercuryProject.Application.Idea.Queries.GetIdeaById
{
    public record GetIdeaByIdQuery(string Id) : IRequest<ErrorOr<IdeaResult>>;
}
