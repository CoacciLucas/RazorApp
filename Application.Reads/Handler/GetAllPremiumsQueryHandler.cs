using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Reads.Handler;

public class GetAllPremiumsQueryHandler : IRequestHandler<GetAllPremiumsQuery, List<PremiumDTO>>
{
    private readonly IPremiumService _premiumService;
    private readonly IMapper _mapper;
    public GetAllPremiumsQueryHandler(IPremiumService premiumService, IMapper mapper)
    {
        _premiumService = premiumService;
        _mapper = mapper;
    }
    public async Task<List<PremiumDTO>> Handle(GetAllPremiumsQuery request, CancellationToken cancellationToken)
    {
        var premium = await _premiumService.GetAllAsyncAsNoTracking();
        return _mapper.Map<List<PremiumDTO>>(premium);
    }
}
