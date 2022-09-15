using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DistributedCacheHelper
{
    public static class DistributedCacheExtensions
    {
        public static async Task SetDataAsync<T>(this IDistributedCache distributedCache, string key, T data, TimeSpan? absoluteExpiration, TimeSpan? slidingExpiration = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiration ??= TimeSpan.FromSeconds(300),
                SlidingExpiration = slidingExpiration
            };
            await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(data), options);
        }
        public static async Task<T> GetDataAsync<T>(this IDistributedCache distributedCache, string key)
        {
            var cachedData = await distributedCache.GetStringAsync(key);
            if (!string.IsNullOrEmpty(cachedData))
            {
                return JsonConvert.DeserializeObject<T>(cachedData);
            }
            else
            {
                return default(T);
            }
        }
    }
}
