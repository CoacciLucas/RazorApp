using Application.Reads.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace RazorApp.Pages.Students;

public class EditModel : PageModel
{
    private readonly IStudentService _studentService;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    public EditModel(IStudentService studentService, IMapper mapper, IStudentRepository studentRepository)
    {
        _studentService = studentService;
        _mapper = mapper;
        _studentRepository = studentRepository;
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

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var student = _mapper.Map<Student>(Student);
            await _studentRepository.UpdateAsync(student);
            
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(Student.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool StudentExists(int id)
    {
        var student = _studentService.GetByIdAsyncAsNoTracking(id);
        return student != null;
    }
}
