using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class PremiumService : IPremiumService
{
    private readonly IPremiumRepository _premiumRepository;

    public PremiumService(IPremiumRepository premiumRepository)
    {
        _premiumRepository = premiumRepository;
    }

    public async Task<List<Premium>> GetAllAsyncAsNoTracking()
    {
        return await _premiumRepository.GetAllAsyncAsNoTracking();
    } 
    public async Task<Premium?> GetByIdAsyncAsNoTracking(Guid id)
    {
        return await _premiumRepository.GetByIdAsyncAsNoTracking(id);
    }
    public async Task<Premium?> GetByIdAsync(Guid id)
    {
        return await _premiumRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Premium premium)
    {
        await _premiumRepository.UpdateAsync(premium);
    }
}
