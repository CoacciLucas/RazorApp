using Application.Reads.DTOs;

namespace Domain.Services.Interfaces;

public interface IStudentService
{
    Task<StudentDTO> GetByIdAsync(int id);
    Task<StudentDTO> GetByIdAsyncAsNoTracking(int id);
}