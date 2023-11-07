using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages.Premiums;

public class DeleteModel : PageModel
{
    private readonly Data.AppDbContext _context;

    public DeleteModel(Data.AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null || _context.Premiums == null)
        {
            return NotFound();
        }
        var premium = await _context.Premiums.FindAsync(id);

        if (premium != null)
        {
            Premium = premium;
            _context.Premiums.Remove(Premium);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
