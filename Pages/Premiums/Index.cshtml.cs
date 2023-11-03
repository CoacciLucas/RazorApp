using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages_Premiums
{
    public class IndexModel : PageModel
    {
        private readonly RazorApp.Data.ApplicationDbContext _context;

        public IndexModel(RazorApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Premium> Premium { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Premiums != null)
            {
                Premium = await _context.Premiums
                .Include(p => p.Student).ToListAsync();
            }
        }
    }
}
