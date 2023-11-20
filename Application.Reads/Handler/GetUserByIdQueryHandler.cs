using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Reads.Handler;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IdentityUserDTO>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    public async Task<IdentityUserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByIdAsyncAsNoTracking(request.Id.ToString());

        return _mapper.Map<IdentityUserDTO>(user);
    }
}
