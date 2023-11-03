namespace Infra.Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void Commit();

    Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
}
