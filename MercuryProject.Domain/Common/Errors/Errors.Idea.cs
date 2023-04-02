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
        public static class Idea
        {
            public static Error DuplicateIdeaName =>
                Error.Conflict(code: "Product.DuplicateIdeaName", description: "This idea name is already in use.");
            public static Error IdeaNotFound =>
                Error.NotFound(code: "Idea.NotFound", description: "Idea with this id doesn't exists");
            public static Error CorrectId =>
                Error.Conflict(code: "Idea.CorrectId", description: "Specify the correct format of id");
        }
    }
}
