using BlogProgram.Application.Interfaces;
using BlogProgram.Domain.Entities;
using BlogProgram.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogProgram.Infrastructure.Implementation
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public DbSet<T> _entityDbSet { get; set; }

        public GenericRepository(DataBaseContext dbContext)
        {
            _entityDbSet = dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            await _entityDbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _entityDbSet.Remove(entity);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, List<string> includes = null)
        {
            IQueryable<T> query = _entityDbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                    query.Include(include);
            }

            if (filter != null) return query.Where(filter);
            return query;
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> filter, List<string> includes = null)
        {
            IQueryable<T> query = _entityDbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                    query.Include(include);
            }

            return query.FirstOrDefaultAsync(filter);
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;

            _entityDbSet.Update(entity);
        }

    }
}
