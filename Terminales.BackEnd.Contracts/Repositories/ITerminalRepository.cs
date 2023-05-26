using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminales.Backend.Contracts.Models;

namespace Terminales.Backend.Contracts.Repositories
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        Task<IEnumerable<Terminal>> GetAllAvailablesAsync();
    }
}
