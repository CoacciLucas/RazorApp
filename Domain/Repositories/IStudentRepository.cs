using Domain.Entities;

namespace Domain.Repositories;

public interface IStudentRepository : IRepository<Student>
{
    Task<Student?> GetByIdAsync(Guid id);
    Task<Student?> GetByIdAsyncAsNoTracking(Guid id);
}
