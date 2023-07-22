using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace QapaqMantenimiento.Shared
{
    public class SubTipoDTO
    {
        public int IdSubTipo { get; set; }
        public string? SubTipoIncidente { get; set; }
        public string? AreaEncargada { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string? Correo { get; set; }
        [Required]
        [Range(0,int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdTipoIncidente { get; set; }

        public TipoIncidenteDTO? TipoIncidente { get; set; }
    }
}
