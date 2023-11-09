using Domain.Entities;

namespace Domain.Services.Interfaces;

public interface IStudentService
{
    Task<List<Student>> GetAllAsyncAsNoTracking();
    Task<Student?> GetByIdAsync(Guid id);
    Task<Student?> GetByIdAsyncAsNoTracking(Guid id);
}