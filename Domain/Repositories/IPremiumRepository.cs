﻿using Domain.Entities;

namespace Domain.Repositories;

public interface IPremiumRepository : IRepository<Premium>
{
    Task<List<Premium>> GetAllAsyncAsNoTracking();
    Task<Premium?> GetByIdAsync(Guid id);
    Task<Premium?> GetByIdAsyncAsNoTracking(Guid id);
}
