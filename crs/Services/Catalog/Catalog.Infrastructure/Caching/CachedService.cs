using Catalog.Infrastructure.Caching.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Catalog.Infrastructure.Caching;

internal class CachedService(IDistributedCache cache) : ICachedService
{
    protected readonly IDistributedCache _cache = cache;

    protected static DistributedCacheEntryOptions GetOptions(TimeSpan expirationTime = default) =>
     new()
     {
         AbsoluteExpiration = expirationTime == default ?
         null : DateTime.Now.Add(expirationTime)
     };

    public async Task<T?> GetAsync<T>(
        string key,
        CancellationToken cancellationToken = default)
    {
        var result = await _cache.GetStringAsync(key, cancellationToken);

        if (result is null)
        {
            return default;
        }

        await _cache.RefreshAsync(key, cancellationToken);
        return JsonSerializer.Deserialize<T>(result);
    }
    public async Task SetAsync<T>(
        string key,
        T value,
        TimeSpan expirationTime = default,
        CancellationToken cancellationToken = default)
    {
        var serializeObject = JsonSerializer.Serialize(value);
        var options = GetOptions(expirationTime);

        await _cache.SetStringAsync(key, serializeObject, options, cancellationToken);
    }

    public async Task RefreshAsync(string key, CancellationToken cancellationToken = default) => 
        await _cache.RefreshAsync(key, cancellationToken);

    public async Task DeleteAsync(string key, CancellationToken cancellationToken = default) => 
        await _cache.RemoveAsync(key, cancellationToken);
}
