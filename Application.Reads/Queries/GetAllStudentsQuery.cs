using Application.Reads.DTOs;
using MediatR;

namespace Application.Reads.Queries;

public class GetAllStudentsQuery : IRequest<List<StudentDTO>>
{
}
