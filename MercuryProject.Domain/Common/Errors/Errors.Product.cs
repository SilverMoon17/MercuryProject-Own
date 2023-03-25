using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error DuplicateProductName =>
                Error.Conflict(code: "Product.DuplicateProductName", description: "This product name is already in use.");
            public static Error TooLongDescription =>
                Error.Conflict(code: "Product.TooLongDescription", description: "Description too long (only 500 characters available)");
        }
    }
}
