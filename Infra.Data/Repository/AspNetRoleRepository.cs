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
}
