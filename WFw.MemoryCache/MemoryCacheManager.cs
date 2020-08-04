using Microsoft.Extensions.Caching.Memory;
using System;
using WFw.ICache;

namespace WFw.MemoryCache
{
    /// <summary>
    /// 
    /// </summary>
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoryCache"></param>
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set<Entity>(string key, Entity value)
        {
            _memoryCache.Set(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheDurationInSeconds"></param>
        public void Set<Entity>(string key, Entity value, int cacheDurationInSeconds)
        {
            DateTime expire = DateTime.Now.AddSeconds(cacheDurationInSeconds);
            _memoryCache.Set(key, value, new DateTimeOffset(expire));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Entity Get<Entity>(string key)
        {
            if (ContainsKey(key))
            {
                return _memoryCache.Get<Entity>(key);
            }
            return default;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return Get<string>(key);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        public void Del(params string[] keys)
        {
            foreach (var key in keys)
            {
                _memoryCache.Remove(key);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey<Entity>(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return ContainsKey<string>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Compare(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            if (!ContainsKey(key))
            {
                return false;
            }
            return value.Equals(Get(key), StringComparison.Ordinal);
        }

    }
}
