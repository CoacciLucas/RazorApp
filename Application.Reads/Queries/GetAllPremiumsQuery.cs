using Application.Reads.DTOs;
using MediatR;

namespace Application.Reads.Queries;

public class GetAllPremiumsQuery : IRequest<List<PremiumDTO>>
{
}
