using Domain.Entities;

namespace Domain.Repositories;

public interface IStudentRepository : IRepository<Student>
{
    Task<Student> GetByIdAsync(int id);
    Task<Student> GetByIdAsyncAsNoTracking(int id);
}
