﻿using Catalog.Core.Common;

namespace Catalog.Infrastructure.Caching.Abstractions;

public interface ICachedEntityService<TEntity, TStrongestId>
    where TEntity : Entity<TStrongestId>
    where TStrongestId : class, IStrongestId
{
    Task DeleteAsync(TStrongestId id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(TStrongestId id, CancellationToken cancellationToken = default);
    Task RefreshAsync(TStrongestId id, CancellationToken cancellationToken = default);
    Task SetAsync(TEntity entity, TimeSpan expirationDate = default, CancellationToken cancellationToken = default);
    Task SetAsync(IEnumerable<TEntity> entities, TimeSpan expirationDate = default, CancellationToken cancellationToken = default);
}
