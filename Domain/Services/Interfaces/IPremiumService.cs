using Domain.Entities;

namespace Domain.Services.Interfaces;

public interface IPremiumService
{
    Task<List<Premium>> GetAllAsyncAsNoTracking();
    Task<Premium?> GetByIdAsync(Guid id);
    Task<Premium?> GetByIdAsyncAsNoTracking(Guid id);
    Task UpdateAsync(Premium premium);
}
