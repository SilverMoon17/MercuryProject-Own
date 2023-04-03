using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.Idea.Commands.Delete
{
    internal class IdeaDeleteCommandHandler : IRequestHandler<IdeaDeleteCommand, ErrorOr<bool>>
    {
        private readonly IIdeaRepository _ideaRepository;

        public IdeaDeleteCommandHandler(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task<ErrorOr<bool>> Handle(IdeaDeleteCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (Guid.TryParse(request.Id, out var productGuid))
            {
                Domain.Idea.Idea idea = await _ideaRepository.GetIdeaById(productGuid);

                if (idea is null)
                {
                    return Errors.Idea.IdeaNotFound;
                }

                bool status = await _ideaRepository.DeleteIdea(idea);

                return status;
            }

            return Errors.Idea.CorrectId;
        }
    }
}
