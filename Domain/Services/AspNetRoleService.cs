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
}
