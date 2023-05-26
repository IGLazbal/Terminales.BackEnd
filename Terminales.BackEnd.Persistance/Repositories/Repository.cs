using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminales.Backend.Contracts.Repositories;

namespace Terminales.Backend.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string _cacheKeyPrefix;

        public Repository(DbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
            _cacheKeyPrefix = typeof(TEntity).Name;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var cacheKey = GetCacheKey(nameof(GetAllAsync));
            if (_cache.TryGetValue(cacheKey, out IEnumerable<TEntity> cachedData))
            {
                return cachedData;
            }

            var data = await _context.Set<TEntity>().ToListAsync();
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };

            _cache.Set(cacheKey, data, cacheOptions);
            return data;
        }

        public string GetCacheKey(params string[] keyParts)
        {
            return $"{_cacheKeyPrefix}:{string.Join(":", keyParts)}";
        }
    }
}
