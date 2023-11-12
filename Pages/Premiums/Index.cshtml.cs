using Application.Reads.DTOs;
using Application.Reads.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Premiums;

public class IndexModel : PageModel
{
    private readonly IMediator _handle;
    public IndexModel(IMediator handle)
    {
        _handle = handle;
    }

    public IList<PremiumDTO> Premium { get; set; } = default!;

    public async Task OnGetAsync()
    {
        var result = await _handle.Send(new GetAllPremiumsQuery());

        Premium = result;
    }
}
