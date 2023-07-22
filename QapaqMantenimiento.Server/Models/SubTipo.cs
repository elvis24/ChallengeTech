using System;
using System.Collections.Generic;

namespace QapaqMantenimiento.Server.Models
{
    public partial class SubTipo
    {
        public int IdSubTipo { get; set; }
        public string? SubTipoIncidente { get; set; }
        public string? AreaEncargada { get; set; }
        public string? Correo { get; set; }
        public int IdTipoIncidente { get; set; }

        public virtual TipoIncidente IdTipoIncidenteNavigation { get; set; } = null!;
    }
}
