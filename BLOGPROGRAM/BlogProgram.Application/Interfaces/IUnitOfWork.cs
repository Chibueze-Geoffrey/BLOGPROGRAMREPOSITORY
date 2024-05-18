using BlogProgram.Domain.Entities;

namespace BlogProgram.Application.Interfaces
{
    public interface IUnitOfWork
    {
       // Dictionary<Type, IGenericRepository<BaseEntity>> Repositories { get; set; }
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task CommitAsync();
    }
}
