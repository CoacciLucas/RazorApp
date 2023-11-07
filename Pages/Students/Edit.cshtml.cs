using Application.Reads.DTOs;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Application.Commands;

namespace RazorApp.Pages.Students;

public class EditModel : PageModel
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _handle;
    public EditModel(IStudentRepository studentRepository, IMediator handle, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _handle = handle;
        _mapper = mapper;
    }

    [BindProperty]
    public StudentDTO Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsyncAsNoTracking(id);
        if (student == null)
            return NotFound();
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
        var student = _studentRepository.GetByIdAsyncAsNoTracking(id);
        return student != null;
    }
}
