using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminales.Backend.Contracts;
using Terminales.Backend.Contracts.Models;
using Terminales.Backend.Contracts.Models.DTOs;
using Terminales.Backend.Contracts.Services;

namespace Terminales.Backend.Services
{
    public class TerminalService : ITerminalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerminalService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TerminalResponseDTO>> GetAllAsync()
        {
            IEnumerable<Terminal> terminales = await _unitOfWork.Terminales.GetAllAsync();

            List<TerminalResponseDTO> terminalResponseDTOs = terminales
                .Select(terminal => new TerminalResponseDTO(terminal))
                .ToList();

            return terminalResponseDTOs;
        }

        public async Task<IEnumerable<TerminalResponseDTO>> GetAllAvailablesAsync()
        {
            IEnumerable<Terminal> terminales = await _unitOfWork.Terminales.GetAllAvailablesAsync();

            List<TerminalResponseDTO> terminalResponseDTOs = terminales
                .Select(terminal => new TerminalResponseDTO(terminal))
                .ToList();

            return terminalResponseDTOs;
        }
    }
}
