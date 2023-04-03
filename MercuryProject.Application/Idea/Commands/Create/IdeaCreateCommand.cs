using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MercuryProject.Application.Idea.Common;

namespace MercuryProject.Application.Idea.Create
{
    public record IdeaCreateCommand
    (
        string Title,
        string Description,
        double Goal,
        string Category,
        List<string> IconUrls
    ) : IRequest<ErrorOr<IdeaResult>>;
}
