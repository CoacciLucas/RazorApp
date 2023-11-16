using Application.Reads.DTOs;
using MediatR;

namespace Application.Reads.Queries;

public class GetRoleByIdQuery : IRequest<IdentityRoleDTO>
{
    public GetRoleByIdQuery(Guid id) => Id = id;
    public Guid Id { get; set; }
}
