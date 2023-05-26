using Microsoft.AspNetCore.Mvc;
using Terminales.Backend.Contracts.Models;
using Terminales.Backend.Contracts.Models.DTOs;
using Terminales.Backend.Contracts.Services;

namespace Terminales.Controllers
{
    [ApiController]
    [Route("api/terminales")]
    public class TerminalController : ControllerBase
    {
        private readonly ITerminalService _terminalService;

        public TerminalController(ITerminalService terminalService)
        {
            this._terminalService = terminalService;
        }

        [HttpGet]
        public async Task<IEnumerable<TerminalResponseDTO>> GetAllAvailablesAsync()
        {
            return await _terminalService.GetAllAvailablesAsync();
        }
    }
}