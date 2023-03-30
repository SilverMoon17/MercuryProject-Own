using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ErrorOr;
using MercuryProject.Application.Product.Common;

namespace MercuryProject.Application.Product.Queries.GetProductById
{
    public record GetProductByIdQuery(string Id) : IRequest<ErrorOr<ProductResult>>;
}
