using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminales.Backend.Contracts.Models.DTOs;

namespace Terminales.Backend.Contracts.Services
{
    public interface ITerminalService
    {
        Task<IEnumerable<TerminalResponseDTO>> GetAllAsync();
        Task<IEnumerable<TerminalResponseDTO>> GetAllAvailablesAsync();

    }
}
