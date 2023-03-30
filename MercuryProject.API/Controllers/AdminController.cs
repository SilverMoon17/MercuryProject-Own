using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.Authentication.Commands.Register;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Product.Commands.Create;
using MercuryProject.Application.Product.Common;
using MercuryProject.Contracts.Admin;
using MercuryProject.Contracts.Authentication;
using MercuryProject.Contracts.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MercuryProject.API.Controllers
{
    [Route("admin")]
    [Authorize(Roles = "Developer,Admin")]
    public class AdminController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AdminController(IUserRepository userRepository, ISender mediator, IMapper mapper)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPatch]
        public async Task<IActionResult> AddAdmin(AddAdminRequest request)
        {
            ErrorOr<bool> result= await _userRepository.AddAdminByUsername(request.Username);

            return result.Match(result => Ok(),
                errors => Problem(errors));
        }

        [HttpPost("product")]
        public async Task<IActionResult> CreateProduct(ProductCreateRequest request)
        {
            var command = _mapper.Map<ProductCreateCommand>(request);
            ErrorOr<ProductResult> result = await _mediator.Send(command);

            return result.Match(result => Ok(_mapper.Map<ProductResponse>(result)),
                errors => Problem(errors));
        }


    }
}
