namespace Core.Application.Pipelines.Caching;

public interface ICachableRequest
{
    bool BypassCache { get; } //Önbelleğe almayı atlayıp doğrudan veritabanına gitmek isteyip istemediğinizi belirler
    string CacheKey { get; } //Her benzer istek için benzersiz bir önbellek anahtarı belirler
    TimeSpan? SlidingExpiration { get; } //Önbelleğin bellekte tutulması gereken saat cinsinden süre
}