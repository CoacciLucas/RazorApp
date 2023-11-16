using Application.Commands.Commands;
using Application.Reads.DTOs;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    public IActionResult OnGet()
    {
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
            var result = await _handle.Send(new CreateRoleCommand(Role.Name));
        }
        catch (Exception)
        {
            TempData["error"] = "Error while creating role";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "Role created successfully";
        return RedirectToPage("./Index");
    }
}
