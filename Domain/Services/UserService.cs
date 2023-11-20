using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<IdentityUser>> GetAllAsyncAsNoTracking()
    {
        return await _userManager.Users
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }
    public async Task<IdentityUser?> GetByIdAsyncAsNoTracking(string id)
    {
        return await _userManager.Users
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<IdentityUser?> GetByIdAsync(string id)
    {
        return await _userManager.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<string>> GetRolesAsync(IdentityUser user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);
        var roles = new List<string>();
        roles.AddRange(userRoles);
        return roles;
    }
}
