using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Reads.Handler;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDTO>
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    public GetStudentByIdQueryHandler(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    public async Task<StudentDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetByIdAsyncAsNoTracking(request.Id);

        return _mapper.Map<StudentDTO>(student);
    }
}
