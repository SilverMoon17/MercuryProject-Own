using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Idea;
using MercuryProject.Domain.Idea.ValueObjects;
using MercuryProject.Domain.Product;
using MercuryProject.Domain.Product.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace MercuryProject.Infrastructure.Persistence.Repositories
{
    public class IdeaRepository : IIdeaRepository
    {
        private readonly MercuryProjectDbContext _dbContext;

        public IdeaRepository(MercuryProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Idea?> GetIdeaByTitle(string title)
        {
            return await _dbContext.Set<Idea>().FirstOrDefaultAsync(u => u.Title == title);
        }

        public async Task<Idea?> GetIdeaById(string id)
        {
            var ideaId = IdeaId.Create(new Guid(id));
            var idea = await _dbContext.Set<Idea>().FirstOrDefaultAsync(p => p.Id == ideaId);

            return idea;
        }

        public async Task<bool> DeleteIdea(Idea idea)
        {
            try
            {
                _dbContext.Remove(idea);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Idea>> GetAllIdeasAsync()
        {
            return await _dbContext.Set<Idea>().ToListAsync();
        }

        public void Add(Idea idea)
        {
            _dbContext.AddAsync(idea);
            _dbContext.SaveChangesAsync();
        }
    }
}
