using Application.Reads.DTOs;
using MediatR;

namespace Application.Reads.Queries;

public class GetUserByIdQuery : IRequest<IdentityUserDTO>
{
    public GetUserByIdQuery(Guid id) => Id = id;
    public Guid Id { get; set; }
}