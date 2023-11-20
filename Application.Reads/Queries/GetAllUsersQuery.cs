using Application.Reads.DTOs;
using MediatR;

namespace Application.Reads.Queries;

public class GetAllUsersQuery : IRequest<List<IdentityUserDTO>>
{
}
