using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Reads.Handler;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<IdentityUserDTO>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public GetAllUsersQueryHandler(IUserService premiumService, IMapper mapper)
    {
        _userService = premiumService;
        _mapper = mapper;
    }
    public async Task<List<IdentityUserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsyncAsNoTracking();
        var usersDTO = new List<IdentityUserDTO>();

        foreach (var user in users)
        {
            var userRoles = await _userService.GetRolesAsync(user);
            var userDTO = _mapper.Map<IdentityUserDTO>(user);
            userDTO.Roles.AddRange(userRoles);
            usersDTO.Add(userDTO);
        }

        return usersDTO;
    }
}
