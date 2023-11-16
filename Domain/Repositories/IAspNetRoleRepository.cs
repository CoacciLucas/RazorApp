using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories;

public interface IAspNetRoleRepository : IRepository<IdentityRole>
{
    Task<List<IdentityRole>> GetAllAsyncAsNoTracking();
    Task<IdentityRole?> GetByIdAsync(string id);
    Task<IdentityRole?> GetByIdAsyncAsNoTracking(string id);
}
