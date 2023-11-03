using Application.Reads.DTOs;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Students;

public class DetailsModel : PageModel
{
    private readonly IStudentService _studentService;

    public DetailsModel(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public StudentDTO Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var student = await _studentService.GetByIdAsyncAsNoTracking(id);
        if (student == null)
            return NotFound();

        Student = student;

        return Page();
    }
}
