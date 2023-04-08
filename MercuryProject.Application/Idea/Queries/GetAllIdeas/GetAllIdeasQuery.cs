using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace MercuryProject.Application.Idea.Queries.GetAllIdeas
{
    public record GetAllIdeasQuery
        (Expression<Func<Domain.Idea.Idea, bool>> Predicate) : IRequest<IEnumerable<Domain.Idea.Idea>>;
}
