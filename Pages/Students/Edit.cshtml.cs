using Application.Reads.DTOs;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Application.Commands;

namespace RazorApp.Pages.Students;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    private readonly IMediator _handle;
    public EditModel(IStudentService studentService, IMediator handle, IMapper mapper)
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
        {
            TempData["error"] = "Student not found";
            return RedirectToPage("./Index");
        }
        Student = _mapper.Map<StudentDTO>(student);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var result = await _handle.Send(new EditStudentCommand(Student.Id, Student.Name, Student.Email));

        if (!result.Success)
            TempData["error"] = "Error while editing student";

        if (!StudentExists(Student.Id))
        {
            TempData["error"] = "Student not found";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "Student edited successfully";
        return RedirectToPage("./Index");
    }

    private bool StudentExists(Guid id)
    {
        var student = _studentService.GetByIdAsyncAsNoTracking(id);
        return student != null;
    }
}
