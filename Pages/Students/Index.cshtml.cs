using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages.Students;

public class IndexModel : PageModel
{
    private readonly Data.AppDbContext _context;

    public IndexModel(Data.AppDbContext context)
    {
        _context = context;
    }

    public IList<Student> Student { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Students != null)
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
