using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }
    
    public async Task<Student?> GetByIdAsyncAsNoTracking(Guid id)
    {
        return await _studentRepository.GetByIdAsyncAsNoTracking(id);
    }
    public async Task<List<Student>> GetAllAsyncAsNoTracking()
    {
        return await _studentRepository.GetAllAsyncAsNoTracking();
    }
}
