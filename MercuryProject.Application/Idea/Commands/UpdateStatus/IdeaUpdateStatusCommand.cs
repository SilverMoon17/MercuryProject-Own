using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Contracts.Idea;
using MercuryProject.Domain.Enums;

namespace MercuryProject.Application.Idea.Commands.Approve
{
    public record IdeaUpdateStatusCommand(string Id, IdeaStatus Status) : IRequest<ErrorOr<Domain.Idea.Idea>>;
}
