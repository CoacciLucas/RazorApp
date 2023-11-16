using Application.Commands.Commands;
using Application.Reads.DTOs;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Roles;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly IAspNetRoleService _roleService;
    private readonly IMapper _mapper;
    private readonly IMediator _handle;
    public DeleteModel(IAspNetRoleService roleService, IMapper mapper, IMediator handle)
    {
        _roleService = roleService;
        _mapper = mapper;
        _handle = handle;
    }

    [BindProperty]
    public IdentityRoleDTO Role { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var role = await _roleService.GetByIdAsyncAsNoTracking(id.ToString());
        if (role == null)
            TempData["error"] = "Role not found!";

        Role = _mapper.Map<IdentityRoleDTO>(role);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        var result = await _handle.Send(new DeleteRoleCommand(id));

        if (!result.Success)
            TempData["error"] = "Error while editing Role";

        if (!RoleExists(id))
        {
            TempData["error"] = "Role not found";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "Role deleted successfully";
        return RedirectToPage("./Index");
    }
    private bool RoleExists(Guid id)
    {
        return (_roleService.GetByIdAsyncAsNoTracking(id.ToString()) != null);
    }
}
