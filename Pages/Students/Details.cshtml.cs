using Application.Reads.DTOs;
using AutoMapper;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Students;

public class DetailsModel : PageModel
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public DetailsModel(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public StudentDTO Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsyncAsNoTracking(id);
        if (student == null)
            return NotFound();

        Student = _mapper.Map<StudentDTO>(student);

        return Page();
    }
}
