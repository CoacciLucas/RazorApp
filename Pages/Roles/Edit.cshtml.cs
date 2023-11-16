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
public class EditModel : PageModel
{
    private readonly IAspNetRoleService _roleService;
    private readonly IMediator _handle;
    private readonly IMapper _mapper;
    public EditModel(IAspNetRoleService roleService,
        IMediator handle,
        IMapper mapper)
    {
        _roleService = roleService;
        _handle = handle;
        _mapper = mapper;
    }

    [BindProperty]
    public IdentityRoleDTO Role { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var role = await _roleService.GetByIdAsyncAsNoTracking(id.ToString());

        Role = _mapper.Map<IdentityRoleDTO>(role);

        return Page();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var result = await _handle.Send(new EditRoleCommand(Role.Id, Role.NormalizedName));

        if (!result.Success)
            TempData["error"] = "Error while editing role";

        if (!RoleExists(Role.Id))
        {
            TempData["error"] = "Role not found";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "Role edited successfully";

        return RedirectToPage("./Index");
    }

    private bool RoleExists(Guid id)
    {
        return (_roleService.GetByIdAsyncAsNoTracking(id.ToString()) != null);
    }
}
