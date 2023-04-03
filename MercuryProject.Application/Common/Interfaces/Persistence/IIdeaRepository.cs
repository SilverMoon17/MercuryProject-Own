using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Common.Errors;
using MercuryProject.Domain.Enums;
using MercuryProject.Domain.Idea;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IIdeaRepository
    {
        Task<Domain.Idea.Idea?> GetIdeaByTitle(string title);
        Task<Domain.Idea.Idea?> GetIdeaById(Guid id);
        Task<bool> DeleteIdea(Domain.Idea.Idea idea);
        Task<IEnumerable<Domain.Idea.Idea>> GetAllIdeasAsync();
        Task<IEnumerable<Domain.Idea.Idea>> GetAllWhereAsync(Expression<Func<Domain.Idea.Idea, bool>> predicate);
        public void UpdateIdeaCollectedMoney(Domain.Idea.Idea idea, double donate);
        public void UpdateIdeaStatus(Domain.Idea.Idea idea, IdeaStatus status);
        void Add(Domain.Idea.Idea idea);
    }
}
