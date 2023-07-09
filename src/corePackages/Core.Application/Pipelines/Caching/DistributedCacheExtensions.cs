using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Core.Application.Pipelines.Caching
{
    public static class DistributedCacheExtensions
    {
        public static async Task<bool> IsCacheKeyExists(this IDistributedCache cache, string cacheKey, CancellationToken cancellationToken)
        {
            byte[] cachedData = await cache.GetAsync(cacheKey, cancellationToken);

            return cachedData != null;
        }

        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.All
            };
        }
    }
}