using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminales.Backend.Contracts.Models.DTOs
{
    public class TerminalResponseDTO
    {
        public TerminalResponseDTO() { }
        public TerminalResponseDTO(Terminal terminal)
        {
            this.NombreTerminal = terminal.Name;
            this.DescripcionTerminal = terminal.Description;
            this.NombreFabricante = terminal.Fabricante.Name;
            this.NombreEstado = terminal.Estado.Name;
            this.FechaFabricacion = terminal.FechaFabricacion;
            this.FechaEstado = terminal.FechaEstado;

        }
        public string NombreTerminal { get; set; }
        public string DescripcionTerminal { get; set; }
        public string NombreFabricante { get; set; }
        public string NombreEstado { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaEstado { get; set; }
    }
}
