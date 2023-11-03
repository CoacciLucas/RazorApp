using Infra.Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using RazorApp.Data;

namespace Infra.Data.Base.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(AppDbContext context, IMediator mediator, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _mediator = mediator;
        _logger = logger;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        // Dispatch Domain Events collection. 
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
        // performed through the DbContext will be committed
        var result = await _context.SaveChangesAsync();

        _logger.LogTrace("Is CommitAsync DataBase Results", result);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
