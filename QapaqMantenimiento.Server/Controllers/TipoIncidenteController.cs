using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using QapaqMantenimiento.Server.Models;
using QapaqMantenimiento.Shared;
using Microsoft.EntityFrameworkCore;

namespace QapaqMantenimiento.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIncidenteController : ControllerBase
    {
        private readonly FinancieraQapaqContext _dbContext;

        public TipoIncidenteController(FinancieraQapaqContext dbContext)
        {
               _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TipoIncidenteDTO>>();
            var listaTipoIncidenteDTO = new List<TipoIncidenteDTO>();

            try
            {
                foreach (var item in await _dbContext.TipoIncidentes.ToListAsync())
                {
                    listaTipoIncidenteDTO.Add(new TipoIncidenteDTO
                    {
                        IdTipoIncidente = item.IdTipoIncidente,
                        Tipo=item.Tipo
                    });
                }
                responseApi.esCorrecto = true;
                responseApi.Valor = listaTipoIncidenteDTO;
            }
            catch (Exception ex)
            {
                responseApi.esCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
    }
}
