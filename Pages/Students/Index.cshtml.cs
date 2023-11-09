using Application.Reads.DTOs;
using Application.Reads.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Students;

public class IndexModel : PageModel
{
    private readonly IMediator _handle;

    public IndexModel(IMediator handle)
    {
        _handle = handle;
    }

    public IList<StudentDTO> Student { get; set; } = default!;

    public async Task OnGetAsync()
    {
        var result = await _handle.Send(new GetAllStudentsQuery());

        Student = result;
    }
}
