using Microsoft.AspNetCore.Identity;

namespace Domain.Services.Interfaces;

public interface IUserService
{
    Task<List<IdentityUser>> GetAllAsyncAsNoTracking();
    Task<IdentityUser?> GetByIdAsync(string id);
    Task<IdentityUser?> GetByIdAsyncAsNoTracking(string id);
    Task<List<string>> GetRolesAsync(IdentityUser user);
}
