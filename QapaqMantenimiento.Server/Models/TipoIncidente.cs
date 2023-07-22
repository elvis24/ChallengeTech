using System;
using System.Collections.Generic;

namespace QapaqMantenimiento.Server.Models
{
    public partial class TipoIncidente
    {
        public TipoIncidente()
        {
            SubTipos = new HashSet<SubTipo>();
        }

        public int IdTipoIncidente { get; set; }
        public string? Tipo { get; set; }

        public virtual ICollection<SubTipo> SubTipos { get; set; }
    }
}
