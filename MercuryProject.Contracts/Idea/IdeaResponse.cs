using MercuryProject.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Enums;
using MercuryProject.Domain.User;

namespace MercuryProject.Contracts.Idea
{
    public record IdeaResponse
    (
        Guid Id,
        UserId OwnerId,
        string Title,
        string Description,
        IdeaStatus Status,
        double Goal,
        double Collected,
        string Category,
        List<string> IdeaImageUrls,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
}
