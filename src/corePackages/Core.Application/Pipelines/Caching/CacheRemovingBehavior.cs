using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Core.Application.Pipelines.Caching;

public class CacheRemovingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICacheRemoverRequest
{
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<CacheRemovingBehavior<TRequest, TResponse>> _logger;

    public CacheRemovingBehavior(IDistributedCache distributedCache, ILogger<CacheRemovingBehavior<TRequest, TResponse>> logger
    )
    {
        _distributedCache = distributedCache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
                                        RequestHandlerDelegate<TResponse> next)
    {
        TResponse response;
        if (request.BypassCache) return await next();

        async Task<TResponse> GetResponseAndRemoveCache()
        {
            response = await next();
            foreach (var cacheKey in request.CacheKeys)
            {
                bool isCacheKeyExists = await DistributedCacheExtensions.IsCacheKeyExists(_distributedCache, cacheKey, cancellationToken);
                if (isCacheKeyExists)
                {
                    await _distributedCache.RemoveAsync(cacheKey, cancellationToken);
                    _logger.LogInformation($"Removed Cache -> {cacheKey}");
                }
            }
            return response;
        }

        response = await GetResponseAndRemoveCache();

        return response;
    }
}