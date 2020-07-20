using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using WFw.Cache;

namespace WFw.MemoryCache
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Set<Entity>(string key, Entity value)
        {
            _memoryCache.Set(key, value);
        }

        public void Set<Entity>(string key, Entity value, int cacheDurationInSeconds)
        {
            DateTime expire = DateTime.Now.AddSeconds(cacheDurationInSeconds);
            _memoryCache.Set(key, value, new DateTimeOffset(expire));
        }

        public Entity Get<Entity>(string key)
        {
            if (ContainsKey(key))
            {
                return _memoryCache.Get<Entity>(key);
            }
            return default;

        }

        public string Get(string key)
        {
            return Get<string>(key);
        }

        public void Del(params string[] keys)
        {
            foreach (var key in keys)
            {
                _memoryCache.Remove(key);
            }
        }

        public bool ContainsKey<Entity>(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public bool ContainsKey(string key)
        {
            return ContainsKey<string>(key);
        }


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
