using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Reads.Handler;

public class GetPremiumByIdQueryHandler : IRequestHandler<GetPremiumByIdQuery, PremiumDTO>
{
    private readonly IPremiumService _premiumService;
    private readonly IMapper _mapper;
    public GetPremiumByIdQueryHandler(IPremiumService premiumService, IMapper mapper)
    {
        _premiumService = premiumService;
        _mapper = mapper;
    }

    public async Task<PremiumDTO> Handle(GetPremiumByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _premiumService.GetByIdAsyncAsNoTracking(request.Id);
        return _mapper.Map<PremiumDTO>(student);
    }
}
