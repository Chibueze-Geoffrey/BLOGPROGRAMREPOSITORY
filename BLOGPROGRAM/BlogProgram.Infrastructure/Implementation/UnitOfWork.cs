using BlogProgram.Application.Interfaces;
using BlogProgram.Domain.Entities;
using BlogProgram.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogProgram.Infrastructure.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }
        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);
        }
    }
}
