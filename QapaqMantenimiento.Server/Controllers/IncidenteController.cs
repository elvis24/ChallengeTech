using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using QapaqMantenimiento.Shared;
using QapaqMantenimiento.Server.Models;

namespace QapaqMantenimiento.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {
        private readonly FinancieraQapaqContext _dbContext;

        public IncidenteController(FinancieraQapaqContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(IncidenteDTO incidenteDTO)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbIncidente = new Incidente
                {
                    NumTicket = incidenteDTO.NumTicket,
                    FechaRegistro=incidenteDTO.FechaRegistro,
                    ReportadoMediante=incidenteDTO.ReportadoMediante,
                    TipoOficina = incidenteDTO.TipoOficina,
                    NomApeUsuario = incidenteDTO.NomApeUsuario,
                    NomAgencia = incidenteDTO.NomAgencia,
                    TelefonoContacto = incidenteDTO.TelefonoContacto,
                    NommbrePc = incidenteDTO.NommbrePc,
                    DetalleIncidente = incidenteDTO.DetalleIncidente

                };
                _dbContext.Incidentes.Add(dbIncidente);
                await _dbContext.SaveChangesAsync();
                if (dbIncidente.IdIncidente!=0)
                {
                    responseApi.esCorrecto = true;
                    responseApi.Valor=dbIncidente.IdIncidente;
                }
            }
            catch (Exception ex)
            {
                responseApi.esCorrecto = false;
                responseApi.Mensaje=ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<IncidenteDTO>>();
            var listaIncidenteDTO = new List<IncidenteDTO>();

            try
            {
                foreach (var item in await _dbContext.Incidentes.ToListAsync())
                {
                    listaIncidenteDTO.Add(new IncidenteDTO
                    {
                        IdIncidente = item.IdIncidente,
                        NumTicket = item.NumTicket,
                        FechaRegistro = item.FechaRegistro,
                        ReportadoMediante = item.ReportadoMediante,
                        TipoOficina = item.TipoOficina,
                        NomApeUsuario=item.NomApeUsuario,
                        NomAgencia=item.NomAgencia,
                        TelefonoContacto=item.TelefonoContacto,
                        NommbrePc=item.NommbrePc,
                        DetalleIncidente=item.DetalleIncidente
                    });
                }
                responseApi.esCorrecto = true;
                responseApi.Valor = listaIncidenteDTO;
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
