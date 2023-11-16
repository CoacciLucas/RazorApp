using Domain.Repositories;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Services;

public class AspNetRoleService : IAspNetRoleService
{
    private readonly IAspNetRoleRepository _aspNetRoleRepository;

    public AspNetRoleService(IAspNetRoleRepository aspNetRoleRepository)
    {
        _aspNetRoleRepository = aspNetRoleRepository;
    }

    public async Task<List<IdentityRole>> GetAllAsyncAsNoTracking()
    {
        return await _aspNetRoleRepository.GetAllAsyncAsNoTracking();
    }

    public async Task<IdentityRole?> GetByIdAsyncAsNoTracking(string id)
    {
        return await _aspNetRoleRepository.GetByIdAsyncAsNoTracking(id);
    }

    public async Task<IdentityRole?> GetByIdAsync(string id)
    {
        return await _aspNetRoleRepository.GetByIdAsync(id);
    }
}
