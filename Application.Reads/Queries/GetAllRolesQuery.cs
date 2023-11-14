using MediatR;

namespace Application.Reads.Queries;

public class GetAllRolesQuery : IRequest<List<RolesDTO>>
{
}
