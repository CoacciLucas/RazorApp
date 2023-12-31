using Application.Commands.Commands;
using Application.Reads.DTOs;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorApp.Pages.Premiums;
[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly IPremiumService _premiumService;
    private readonly IStudentService _studentService;
    private readonly IMediator _handle;
    private readonly IMapper _mapper;
    public EditModel(IPremiumService premiumService, IMediator handle, IStudentService studentService, IMapper mapper)
    {
        _premiumService = premiumService;
        _handle = handle;
        _studentService = studentService;
        _mapper = mapper;
    }

    [BindProperty]
    public PremiumDTO Premium { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var premium = await _premiumService.GetByIdAsyncAsNoTracking(id);
        var students = await _studentService.GetAllAsyncAsNoTracking();
        var studentsWithEmail = students
                            .Select(s => new
                            {
                                Id = s.Id,
                                Text = $"{s.Name} ({s.Email})"
                            })
                            .ToList();
        if (premium == null)
        {
            TempData["error"] = "Student not found";
            return RedirectToPage("./Index");
        }
        Premium = _mapper.Map<PremiumDTO>(premium);

        ViewData["StudentId"] = new SelectList(studentsWithEmail, "Id", "Text");
        return Page();

    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var result = await _handle.Send(new EditPremiumCommand(Premium.Id, Premium.Title, Premium.StartDate, Premium.EndDate, Premium.Student.Id));

        if (!result.Success)
            TempData["error"] = "Error while editing student";

        if (!PremiumExists(Premium.Id))
        {
            TempData["error"] = "Premium not found";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "Premium edited successfully";

        return RedirectToPage("./Index");
    }

    private bool PremiumExists(Guid id)
    {
        return (_premiumService.GetByIdAsyncAsNoTracking(id) != null);
    }
}
