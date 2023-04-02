using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Contracts.Idea
{
    public record IdeaCreateRequest
    (
        string Title,
        string Description,
        double Goal,
        string Category,
        List<string> IconUrls
    );
}
