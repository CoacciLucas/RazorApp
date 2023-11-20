using Application.Reads.DTOs;
using Application.Reads.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly IMediator _handle;

    public IndexModel(IMediator handle)
    {
        _handle = handle;
    }

    public IList<IdentityUserDTO> IdtUser { get; set; } = default!;

    public async Task OnGetAsync()
    {
        var result = await _handle.Send(new GetAllUsersQuery());

        IdtUser = result;
    }
}
