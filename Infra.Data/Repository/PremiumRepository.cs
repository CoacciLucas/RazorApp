using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Base;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;

namespace Infra.Data.Repository;

public class PremiumRepository : Repository<Premium>, IPremiumRepository
{
    public PremiumRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }

    public async Task<Premium?> GetByIdAsyncAsNoTracking(Guid id)
    {
        return await _context.Premiums
            .Include(x => x.Student)
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    public async Task<Premium?> GetByIdAsync(Guid id)
    {
        return await _context.Premiums
            .Include(x => x.Student)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    public async Task<List<Premium>> GetAllAsyncAsNoTracking()
    {
        return await _context.Premiums
            .Include(x => x.Student)
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
}
