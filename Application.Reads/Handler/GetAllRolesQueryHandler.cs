using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Reads.Handler;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<IdentityRoleDTO>>
{
    private readonly IAspNetRoleService _aspNetRoleService;
    private readonly IMapper _mapper;
    public GetAllRolesQueryHandler(IAspNetRoleService premiumService, IMapper mapper)
    {
        _aspNetRoleService = premiumService;
        _mapper = mapper;
    }
    public async Task<List<IdentityRoleDTO>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var role = await _aspNetRoleService.GetAllAsyncAsNoTracking();
        return _mapper.Map<List<IdentityRoleDTO>>(role);
    }
}
