using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorApp.Pages.Premiums
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public CreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Premiums == null || Premium == null)
            {
                return Page();
            }

            _context.Premiums.Add(Premium);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
