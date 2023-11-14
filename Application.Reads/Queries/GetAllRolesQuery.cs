using Application.Reads.DTOs;
using MediatR;

namespace Application.Reads.Queries;

public class GetAllRolesQuery : IRequest<List<IdentityRoleDTO>>
{
}
