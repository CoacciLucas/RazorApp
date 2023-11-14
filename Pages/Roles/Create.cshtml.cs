using Application.Commands.Commands;
using Application.Reads.DTOs;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorApp.Pages.Roles;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly IMediator _handle;
    private readonly IStudentRepository _studentRepository;
    public CreateModel(IMediator handle, IStudentRepository studentRepository)
    {
        _handle = handle;
        _studentRepository = studentRepository;
    }
    public async Task<IActionResult> OnGet()
    {
        var students = await _studentRepository.GetAllAsyncAsNoTracking();
        var studentsWithEmail = students
                                    .Select(s => new
                                    {
                                        Id = s.Id,
                                        Text = $"{s.Name} ({s.Email})"
                                    })
                                    .ToList();
        return Page();
    }


    [BindProperty]
    public IdentityRoleDTO Role { get; set; } = default!;
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
          //  var result = await _handle.Send(new CreatePremiumCommand(Role.Title, Role.StartDate, Role.EndDate, Role.Student.Id));
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
