using Application.Reads.DTOs;
using Application.Reads.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Students;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly IMediator _handle;
    public DetailsModel(IMediator handle)
    {
        _handle = handle;
    }

    public StudentDTO Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var result = await _handle.Send(new GetStudentByIdQuery(id));

        Student = result;
        return Page();
    }
}
