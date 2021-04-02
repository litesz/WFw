using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using System.Threading.Tasks;
using WFw.Cache;

namespace WFw.MemoryCache
{
    /// <summary>
    /// 
    /// </summary>
    public class WFwMemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoryCache"></param>
        public WFwMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetValue<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public (T output, bool IsOk) Get<T>(string key)
        {

            if (_memoryCache.TryGetValue(key, out T output))
            {
                return (output, true);
            }

            return (default, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<(T output, bool IsOk)> GetAsync<T>(string key, CancellationToken token = default)
        {
            return Task.Factory.StartNew(() =>
            {
                if (_memoryCache.TryGetValue(key, out T output))
                {
                    return (output, true);
                }
                return (default, false);
            }, token);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        public long Remove(params string[] keys)
        {
            foreach (var key in keys)
            {
                _memoryCache.Remove(key);
            }
            return keys.Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            return Task.Factory.StartNew(() =>
            {
                _memoryCache.Remove(key);
            }, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public bool Set<T>(string key, T value, CacheItemOptions options)
        {
            _memoryCache.Set(key, value, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = options.AbsoluteExpiration,
                AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow,
                SlidingExpiration = options.SlidingExpiration
            });
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<bool> SetAsync<T>(string key, T value, CacheItemOptions options, CancellationToken token = default)
        {
            return Task.Factory.StartNew(() =>
            {
                _memoryCache.Set(key, value, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = options.AbsoluteExpiration,
                    AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow,
                    SlidingExpiration = options.SlidingExpiration
                });
                return true;
            }, token);
        }

      
    }
}
