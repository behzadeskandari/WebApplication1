using Microsoft.Extensions.Caching.Memory;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InMemoryCache : ICacheSevice
    {

        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        public Task<string> GetCacheValueAsync(string key)
        {
            return Task.FromResult(_cache.Get<string>(key));
        }

        public Task SetCacheValueAsync(string key, string Value)
        {
            _cache.Set(key, Value);
            return Task.CompletedTask;
        }
    }

}
