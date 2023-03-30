using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MercuryProject.Application.Product.Common;
using MercuryProject.Domain.Product.ValueObjects;
using ErrorOr;

namespace MercuryProject.Application.Product.Commands.Delete
{
    public record ProductDeleteCommand(string Id) : IRequest<ErrorOr<bool>>;
}
