﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Enums;
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

        public async Task<Idea?> GetIdeaById(Guid id)
        {
            var ideaId = IdeaId.Create(id);
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
            var ideas = await _dbContext.Set<Idea>().ToListAsync();
            return await _dbContext.Set<Idea>().ToListAsync();
        }

        public async Task<IEnumerable<Idea>> GetAllWhereAsync(Expression<Func<Idea, bool>> predicate)
        {
            return await _dbContext.Set<Idea>().Where(predicate).ToListAsync();
        }

        public void UpdateIdeaCollectedMoney(Idea idea, double donate)
        {
            idea.Collected += donate;
            idea.UpdatedDateTime = DateTime.Now;
            _dbContext.Update(idea);
            _dbContext.SaveChanges();
        }

        public void UpdateIdeaStatus(Idea idea, IdeaStatus status)
        {
            idea.Status = status;
            idea.UpdatedDateTime = DateTime.Now;
            _dbContext.Update(idea);
            _dbContext.SaveChanges();
        }

        public void Add(Idea idea)
        {
            _dbContext.Add(idea);
            _dbContext.SaveChanges();
        }
    }
}