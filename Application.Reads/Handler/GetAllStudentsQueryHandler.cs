using Application.Reads.DTOs;
using Application.Reads.Queries;
using AutoMapper;
using Domain.Services.Interfaces;
using MediatR;

namespace Application.Reads.Handler;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentDTO>>
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    public GetAllStudentsQueryHandler(IStudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    public async Task<List<StudentDTO>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetAllAsyncAsNoTracking();

        return _mapper.Map<List<StudentDTO>>(student);
    }
}
