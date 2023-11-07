using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages.Premiums;

public class DetailsModel : PageModel
{
    private readonly Data.AppDbContext _context;

    public DetailsModel(Data.AppDbContext context)
    {
        _context = context;
    }

    public Premium Premium { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Premiums == null)
        {
            return NotFound();
        }

        var premium = await _context.Premiums.FirstOrDefaultAsync(m => m.Id == id);
        if (premium == null)
        {
            return NotFound();
        }
        else
        {
            Premium = premium;
        }
        return Page();
    }
}
