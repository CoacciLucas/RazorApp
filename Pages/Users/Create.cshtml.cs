using Application.Reads.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Application.Commands;

namespace RazorApp.Pages.Users;

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
            TempData["error"] = "Error while creating user";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "User created successfully";
        return RedirectToPage("./Index");
    }
}
