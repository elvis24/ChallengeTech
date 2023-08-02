using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QapaqMantenimiento.Shared
{
    public class IncidenteDTO
    {
        public int IdIncidente { get; set; }
        public int NumTicket { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? ReportadoMediante { get; set; }
        public string? TipoOficina { get; set; }
        public string? NomApeUsuario { get; set; }
        public string? NomAgencia { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? NommbrePc { get; set; }
        public string? DetalleIncidente { get; set; }
    }

}

