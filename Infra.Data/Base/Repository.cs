using Microsoft.EntityFrameworkCore;
using RazorApp.Data;

namespace Infra.Data.Base;

public abstract class Repository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public virtual void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        await Task.FromResult(_context.Set<TEntity>().Remove(entity));
    }

    public virtual void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<TEntity>().Update(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await Task.FromResult(_context.Set<TEntity>().Update(entity));
    }
}