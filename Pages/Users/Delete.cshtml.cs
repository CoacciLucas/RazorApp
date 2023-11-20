using Application.Commands.Commands;
using Application.Reads.DTOs;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Users;

[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly IStudentService _studentService;
    private readonly IMediator _handle;
    private readonly IMapper _mapper;
    public DeleteModel(IStudentService studentService, IMediator handle, IMapper mapper)
    {
        _studentService = studentService;
        _handle = handle;
        _mapper = mapper;
    }

    [BindProperty]
    public StudentDTO Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var student = await _studentService.GetByIdAsyncAsNoTracking(id);
        if (student == null)
            TempData["error"] = "User not found!";
        Student = _mapper.Map<StudentDTO>(student);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        var result = await _handle.Send(new DeleteStudentCommand(id));

        if (!result.Success)
            TempData["error"] = "Error while editing User";

        if (!UserExists(id))
        {
            TempData["error"] = "User not found";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "User deleted successfully";
        return RedirectToPage("./Index");
    }
    private bool UserExists(Guid id)
    {
        var student = _studentService.GetByIdAsyncAsNoTracking(id);
        return student != null;
    }
}
