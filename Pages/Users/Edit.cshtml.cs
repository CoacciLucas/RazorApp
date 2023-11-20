using Application.Commands.Commands;
using Application.Reads.DTOs;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace RazorApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IUserService _userService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IMediator _handle;
    public EditModel(IUserService userService, IMediator handle, IMapper mapper, RoleManager<IdentityRole> roleManager)
    {
        _userService = userService;
        _handle = handle;
        _mapper = mapper;
        _roleManager = roleManager;
    }
    [BindProperty]
    public IdentityUserDTO IdtUser { get; set; } = default!;

    [BindProperty]
    public List<Guid> SelectedRoles { get; set; } = new();

    [BindProperty]
    public List<IdentityRoleDTO> Roles { get; set; } = new();
    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var user = await GetUserInfo(id);

        if (user == null)
        {
            TempData["error"] = "User not found";
            return RedirectToPage("./Index");
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await GetUserInfo(IdtUser.Id);
            return Page();
        }

        var result = await _handle.Send(new EditUserCommand(IdtUser.Id, IdtUser.UserName, IdtUser.Email, IdtUser.PhoneNumber, SelectedRoles));

        if (!result.Success)
            TempData["error"] = "Error while editing user";

        if (!UserExists(IdtUser.Id))
        {
            TempData["error"] = "User not found";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "User edited successfully";
        return RedirectToPage("./Index");
    }

    private bool UserExists(Guid id)
    {
        var user = _userService.GetByIdAsyncAsNoTracking(id.ToString());
        return user != null;
    }
    private async Task<IdentityUser?> GetUserInfo(Guid id)
    {
        var user = await _userService.GetByIdAsyncAsNoTracking(id.ToString());
        var userDTO = _mapper.Map<IdentityUserDTO>(user);
        var userRoles = await _userService.GetRolesAsync(user);
        userDTO.Roles.AddRange(userRoles);

        var roles = await _roleManager.Roles.ToListAsync();
        Roles = _mapper.Map<List<IdentityRoleDTO>>(roles);
        IdtUser = userDTO;
        return user;
    }
}
