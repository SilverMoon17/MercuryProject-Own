using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Idea;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IIdeaRepository
    {
        Task<Domain.Idea.Idea> GetIdeaByTitle(string title);
        Task<Domain.Idea.Idea?> GetIdeaById(string id);
        Task<bool> DeleteIdea(Domain.Idea.Idea idea);
        Task<IEnumerable<Domain.Idea.Idea>> GetAllIdeasAsync();
        void Add(Domain.Idea.Idea idea);
    }
}
