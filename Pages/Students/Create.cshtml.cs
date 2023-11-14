using Application.Reads.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Application.Commands;

namespace RazorApp.Pages.Students;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly IMediator _handle;
    public CreateModel(IMediator handle)
    {
        _handle = handle;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public StudentDTO Student { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            var result = await _handle.Send(new CreateStudentCommand(Student.Name, Student.Email));
        }
        catch (Exception)
        {
            TempData["error"] = "Error while creating student";
            return RedirectToPage("./Index");
        }
           
        TempData["success"] = "Student created successfully";
        return RedirectToPage("./Index");
    }
}
