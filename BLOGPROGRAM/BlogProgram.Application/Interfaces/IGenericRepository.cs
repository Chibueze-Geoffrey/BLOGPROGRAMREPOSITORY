using BlogProgram.Domain.Entities;
using System.Linq.Expressions;

namespace BlogProgram.Application.Interfaces
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        // CREATE
        Task AddAsync(T entity);

        // READ
        Task<T> GetAsync(Expression<Func<T, bool>> filter, List<string> includes = null);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, List<string> includes = null);

        // UPDATE
        void Update(T entity);

        // DELETE
        void Delete(T entity);
      
    }
}
