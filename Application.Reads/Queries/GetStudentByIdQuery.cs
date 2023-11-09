using Application.Reads.DTOs;
using MediatR;

namespace Application.Reads.Queries;

public class GetStudentByIdQuery : IRequest<StudentDTO>
{
    public GetStudentByIdQuery(Guid id) => Id = id;
    public Guid Id { get; set; }
}
