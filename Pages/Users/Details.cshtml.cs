using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class DetailsModel : PageModel
{
    private readonly IMediator _handle;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public DetailsModel(IMediator handle, IUserService userService, IMapper mapper)
    {
        _handle = handle;
        _userService = userService;
        _mapper = mapper;
    }

    public IdentityUserDTO IdtUser { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var result = await _handle.Send(new GetUserByIdQuery(id));
        if (!UserExists(id))
        {
            TempData["error"] = "User not found";
            return RedirectToPage("./Index");
        }

        var userRoles = await _userService.GetRolesAsync(_mapper.Map<IdentityUser>(result));

        IdtUser = result;
        IdtUser.Roles = userRoles;
        return Page();
    }

    private bool UserExists(Guid id)
    {
        var student = _userService.GetByIdAsyncAsNoTracking(id.ToString());
        return student != null;
    }
}
