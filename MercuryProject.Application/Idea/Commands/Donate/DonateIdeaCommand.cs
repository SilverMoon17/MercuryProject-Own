using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace MercuryProject.Application.Idea.Commands.Donate
{
    public record DonateIdeaCommand(string Id, double Donate) : IRequest<ErrorOr<Domain.Idea.Idea>>;
}
