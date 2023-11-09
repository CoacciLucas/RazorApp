using Domain.Entities;

namespace Domain.Repositories;

public interface IStudentRepository : IRepository<Student>
{
    Task<List<Student>> GetAllAsyncAsNoTracking();
    Task<Student?> GetByIdAsync(Guid id);
    Task<Student?> GetByIdAsyncAsNoTracking(Guid id);
}
