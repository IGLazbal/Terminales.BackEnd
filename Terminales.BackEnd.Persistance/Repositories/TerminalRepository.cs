using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminales.Backend.Contracts.Models;
using Terminales.Backend.Contracts.Repositories;

namespace Terminales.Backend.Persistence.Repositories
{
    public class TerminalRepository : Repository<Terminal> , ITerminalRepository
    {
        private readonly DbContext _context;
        private readonly IMemoryCache _cache;

        public TerminalRepository(DbContext context, IMemoryCache cache) : base(context, cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<Terminal>> GetAllAvailablesAsync()
        {
            var cacheKey = GetCacheKey(nameof(GetAllAvailablesAsync));
            if (_cache.TryGetValue(cacheKey, out IEnumerable<Terminal> cachedData))
            {
                return cachedData;
            }

            var data = await _context.Set<Terminal>().Where(t => t.Estado.Name == "DISPONIBLE").ToListAsync();
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };

            _cache.Set(cacheKey, data, cacheOptions);
            return data;
        }
    }
}
