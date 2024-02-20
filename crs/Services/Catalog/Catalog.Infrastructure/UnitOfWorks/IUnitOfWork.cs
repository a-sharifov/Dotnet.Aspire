namespace Catalog.Infrastructure.UnitOfWorks;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken = default);
}
