using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Services.Interfaces;

public interface IAspNetRoleService
{
    Task<List<IdentityRole>> GetAllAsyncAsNoTracking();
}
