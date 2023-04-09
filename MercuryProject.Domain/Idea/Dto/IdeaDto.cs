using MercuryProject.Domain.Enums;
using MercuryProject.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Idea.ValueObjects;

namespace MercuryProject.Domain.Idea.Dto
{
    public class IdeaDto
    {
        public IdeaId Id { get; set; }
        public UserId OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IdeaStatus Status { get; set; }
        public decimal Goal { get; set; }
        public decimal Collected { get; set; }
        public string Category { get; set; }
        public IReadOnlyList<string> IdeaImageUrls { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
