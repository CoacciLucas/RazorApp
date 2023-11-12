using Application.Commands.Commands;
using Application.Reads.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages.Premiums;

public class DeleteModel : PageModel
{
    private readonly IPremiumService _premiumService;
    private readonly IMapper _mapper;
    private readonly IMediator _handle;
    public DeleteModel(IPremiumService premiumService, IMapper mapper, IMediator handle)
    {
        _premiumService = premiumService;
        _mapper = mapper;
        _handle = handle;
    }

    [BindProperty]
    public PremiumDTO Premium { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var premium = await _premiumService.GetByIdAsyncAsNoTracking(id);
        if (premium == null)
            TempData["error"] = "Premium not found!";
        Premium = _mapper.Map<PremiumDTO>(premium);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id)
    {
        var result = await _handle.Send(new DeletePremiumCommand(id));

        if (!result.Success)
            TempData["error"] = "Error while editing premium";

        if (!PremiumExists(id))
        {
            TempData["error"] = "Premium not found";
            return RedirectToPage("./Index");
        }

        TempData["success"] = "Premium deleted successfully";
        return RedirectToPage("./Index");
    }
    private bool PremiumExists(Guid id)
    {
        return (_premiumService.GetByIdAsyncAsNoTracking(id) != null);
    }
}
