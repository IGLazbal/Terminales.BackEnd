using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminales.Backend.Contracts.Models
{
    public class Terminal
    {
        public int Id { get; set; }
        public int FabricanteId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaEstado { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public Fabricante Fabricante { get; set; }
        public Estado Estado { get; set; }
    }
}
