using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.Authentication.Commands.Register;
using MercuryProject.Application.Authentication.Queries.Login;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Product.Commands.Create;
using MercuryProject.Application.Product.Common;
using MercuryProject.Contracts.Authentication;
using MercuryProject.Contracts.Product;
using MercuryProject.Domain.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("product")]
    [Authorize(Roles = "User")]
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;


        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("/getAllProducts")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var result = await _productRepository.GetAllProductsAsync();


            return Ok(result);
        }
    }
}
