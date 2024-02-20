using Catalog.Infrastructure.DbContexts.Products;

namespace Catalog.Infrastructure.UnitOfWorks;

internal sealed class UnitOfWork(ProductDbContext productDbContext) : IUnitOfWork
{
    private readonly ProductDbContext _productDbContext = productDbContext;

    public async Task Commit(CancellationToken cancellationToken = default) => 
        await _productDbContext.SaveChangesAsync(cancellationToken);
}
