using Application.Reads.DTOs;
using Application.Reads.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages_Premiums
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _handle;
        public IndexModel(IMediator handle)
        {
            _handle = handle;
        }

        public IList<PremiumDTO> Premium { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var result = await _handle.Send(new GetAllPremiumsQuery());

            Premium = result;
        }
    }
}
