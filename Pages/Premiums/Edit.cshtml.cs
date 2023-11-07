using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages.Premiums;

public class EditModel : PageModel
{
    private readonly Data.AppDbContext _context;

    public EditModel(Data.AppDbContext context)
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
        Premium = premium;
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Premium).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PremiumExists(Premium.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool PremiumExists(Guid id)
    {
        return (_context.Premiums?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
