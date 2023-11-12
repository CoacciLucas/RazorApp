using Application.Reads.DTOs;
using MediatR;

namespace Application.Reads.Queries;

public class GetPremiumByIdQuery : IRequest<PremiumDTO>
{
    public GetPremiumByIdQuery(Guid id) => Id = id;
    public Guid Id { get; set; }
}
