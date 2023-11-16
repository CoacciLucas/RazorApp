using Domain.Repositories;
using Infra.Data.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository;

public class AspNetRoleRepository : Repository<IdentityRole>, IAspNetRoleRepository
{
    public AspNetRoleRepository(RazorApp.Data.AppDbContext appDbContext) : base(appDbContext)
    {

    }
    public async Task<List<IdentityRole>> GetAllAsyncAsNoTracking()
    {
        return await _context.Roles
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
    public async Task<IdentityRole?> GetByIdAsyncAsNoTracking(string id)
    {
        return await _context.Roles
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<IdentityRole?> GetByIdAsync(string id)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
