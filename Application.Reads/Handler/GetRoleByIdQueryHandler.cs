using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Reads.Handler;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, IdentityRoleDTO>
{
    private readonly IAspNetRoleService _aspNetRoleService;
    private readonly IMapper _mapper;
    public GetRoleByIdQueryHandler(IAspNetRoleService premiumService, IMapper mapper)
    {
        _aspNetRoleService = premiumService;
        _mapper = mapper;
    }
    public async Task<IdentityRoleDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _aspNetRoleService.GetByIdAsyncAsNoTracking(request.Id.ToString());
        return _mapper.Map<IdentityRoleDTO>(role);
    }
}
