using Application.Reads.DTOs;
using AutoMapper;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentDTO> GetByIdAsyncAsNoTracking(int id)
    {
        var student = await _studentRepository.GetByIdAsyncAsNoTracking(id);
        return _mapper.Map<StudentDTO>(student);
    }

    public async Task<StudentDTO> GetByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        return _mapper.Map<StudentDTO>(student);
    }

}
