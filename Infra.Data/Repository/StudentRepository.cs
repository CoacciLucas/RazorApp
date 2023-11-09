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

    public async Task<List<Student>> GetAllAsyncAsNoTracking()
    {
        return await _context.Students
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Student?> GetByIdAsyncAsNoTracking(Guid id)
    {
        return await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _context.Students
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
