using Application.Reads.DTOs;
using Application.Reads.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Premiums;

public class DetailsModel : PageModel
{
    private readonly IMediator _handle;
    public DetailsModel(IMediator handle)
    {
        _handle = handle;
    }

    public PremiumDTO Premium { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var result = await _handle.Send(new GetPremiumByIdQuery(id));

        Premium = result;
        return Page();
    }
}
