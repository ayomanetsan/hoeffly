using Domain.Common;

namespace Application.Common.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    Task AddAsync(T entity, CancellationToken cancellationToken);

    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken);

    Task<ICollection<T>> GetAsync(CancellationToken cancellationToken);

    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);

    void Delete(T entity);

    void Update(T entity);

    IQueryable<T> GetQueryable();
}