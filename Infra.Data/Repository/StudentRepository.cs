using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Base;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;

namespace Infra.Data.Repository;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }

    public async Task<Student> GetByIdAsyncAsNoTracking(int id)
    {
        return await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    public async Task<Student> GetByIdAsync(int id)
    {
        return await _context.Students
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
