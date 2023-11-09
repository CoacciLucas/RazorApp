using Domain.Entities;

namespace Domain.Repositories;

public interface IPremiumRepository : IRepository<Premium>
{
    Task<Premium?> GetByIdAsync(Guid id);
    Task<Premium?> GetByIdAsyncAsNoTracking(Guid id);
}
