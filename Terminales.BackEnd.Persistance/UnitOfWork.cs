using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminales.Backend.Contracts;
using Terminales.Backend.Contracts.Repositories;
using Terminales.Backend.Persistence.Repositories;

namespace Terminales.Backend.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;
        private ITerminalRepository _terminalRepository;

        public UnitOfWork(AppDbContext _context, IMemoryCache _cache) { 
            this._context = _context;
            this._cache = _cache;
        }
        public ITerminalRepository Terminales
        {
            get
            {
                if (_terminalRepository == null)
                    _terminalRepository = new TerminalRepository(_context,_cache);
                return _terminalRepository;
            }
        }
    }
}
