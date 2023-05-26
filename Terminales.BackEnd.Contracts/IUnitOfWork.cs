using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminales.Backend.Contracts.Repositories;

namespace Terminales.Backend.Contracts
{
    public interface IUnitOfWork
    {
        ITerminalRepository Terminales { get; }
    }
}
