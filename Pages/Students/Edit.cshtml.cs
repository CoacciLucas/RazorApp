using Application.Reads.DTOs;
using AutoMapper;
using Domain.Repositories;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Application.Commands;

namespace RazorApp.Pages.Students;

public class EditModel : PageModel
{
    private readonly IStudentService _studentService;
    private readonly IMediator _handle;
    public EditModel(IStudentService studentService, IMediator handle)
    {
        _studentService = studentService;
        _handle = handle;
    }

    [BindProperty]
    public StudentDTO Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var student = await _studentService.GetByIdAsyncAsNoTracking(id);
        if (student == null)
            return NotFound();
        Student = student;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            await _handle.Send(new EditStudentCommand(Student.Id, Student.Name, Student.Email));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(Student.Id))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private bool StudentExists(int id)
    {
        var student = _studentService.GetByIdAsyncAsNoTracking(id);
        return student != null;
    }
}
