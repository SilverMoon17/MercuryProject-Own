using System.Runtime.CompilerServices;
using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Application.Idea.Create;
using MercuryProject.Contracts.Idea;
using MercuryProject.Domain.Idea;
using MercuryProject.Domain.Idea.Dto;
using MercuryProject.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("/idea")]
    public class IdeaController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        private readonly IIdeaRepository _ideaRepository;

        public IdeaController(IMapper mapper, ISender mediator, IIdeaRepository ideaRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _ideaRepository = ideaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIdea(IdeaCreateRequest request)
        {
            var command = _mapper.Map<IdeaCreateCommand>(request);
            ErrorOr<IdeaResult> result = await _mediator.Send(command);

            return result.Match(result => Ok(_mapper.Map<IdeaResponse>(result)),
                errors => Problem(errors));
        }
        [HttpGet("/getAllIdeas")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<IdeaDto>>> GetAllIdeas()
        {
            var ideas = await _ideaRepository.GetAllIdeasAsync();
            var result = _mapper.Map<IEnumerable<IdeaDto>>(ideas);
            return Ok(result);
        }
    }
}
