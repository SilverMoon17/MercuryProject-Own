using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ErrorOr;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Application.Idea.Create;
using MercuryProject.Domain.Common.Errors;
using MercuryProject.Domain.User.ValueObjects;
using MercuryProject.Domain.Idea;


namespace MercuryProject.Application.Idea.Commands.Create
{
    public class IdeaCreateCommandHandler : IRequestHandler<IdeaCreateCommand, ErrorOr<IdeaResult>>
    {
        private readonly IIdeaRepository _ideaRepository;
        private readonly IUserRepository _userRepository;

        public IdeaCreateCommandHandler(IIdeaRepository ideaRepository, IUserRepository userRepository)
        {
            _ideaRepository = ideaRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<IdeaResult>> Handle(IdeaCreateCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (await _ideaRepository.GetIdeaByTitle(request.Title) is not null)
            {
                return Errors.Idea.DuplicateIdeaName;
            }

            var userId = UserId.Create(Guid.Parse(_userRepository.GetUserId()));

            var idea = Domain.Idea.Idea.Create(
                userId,
                request.Title,
                request.Description,
                request.Goal,
                request.Category,
                request.IconUrls);

            _ideaRepository.Add(idea);

            return new IdeaResult(idea);

        }
    }
}
