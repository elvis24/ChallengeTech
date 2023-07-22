using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using QapaqMantenimiento.Server.Models;
using QapaqMantenimiento.Shared;
using Microsoft.EntityFrameworkCore;

namespace QapaqMantenimiento.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTipoController : ControllerBase
    {
        private readonly FinancieraQapaqContext _dbContext;

        public SubTipoController(FinancieraQapaqContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<SubTipoDTO>>();
            var listaSubTipoDTO = new List<SubTipoDTO>();

            try
            {
                foreach (var item in await _dbContext.SubTipos.Include(p=>p.IdTipoIncidenteNavigation).ToListAsync())
                {
                    listaSubTipoDTO.Add(new SubTipoDTO
                    {
                        IdSubTipo = item.IdSubTipo,
                        SubTipoIncidente=item.SubTipoIncidente,
                        AreaEncargada=item.AreaEncargada,
                        Correo=item.Correo,
                        IdTipoIncidente= item.IdTipoIncidente,

                        TipoIncidente=new TipoIncidenteDTO
                        {
                            IdTipoIncidente= item.IdTipoIncidenteNavigation.IdTipoIncidente,
                            Tipo=item.IdTipoIncidenteNavigation.Tipo
                        }
                    });
                }
                responseApi.esCorrecto = true;
                responseApi.Valor = listaSubTipoDTO;
            }
            catch (Exception ex)
            {
                responseApi.esCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var responseApi = new ResponseAPI<SubTipoDTO>();
            var SubTipoDTO = new SubTipoDTO();

            try
            {
                var dbSubtipo = await _dbContext.SubTipos.FirstOrDefaultAsync(x => x.IdSubTipo == id);

                if (dbSubtipo != null) 
                {
                    SubTipoDTO.IdSubTipo = dbSubtipo.IdSubTipo;
                    SubTipoDTO.SubTipoIncidente = dbSubtipo.SubTipoIncidente;
                    SubTipoDTO.AreaEncargada = dbSubtipo.AreaEncargada;
                    SubTipoDTO.Correo = dbSubtipo.Correo;
                    SubTipoDTO.IdTipoIncidente = dbSubtipo.IdTipoIncidente;

                    responseApi.esCorrecto = true;
                    responseApi.Valor = SubTipoDTO;
                }
                else
                {
                    responseApi.esCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.esCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(SubTipoDTO subTipo)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbSubtipo = new SubTipo
                {
                    SubTipoIncidente = subTipo.SubTipoIncidente,
                    AreaEncargada = subTipo.AreaEncargada,
                    Correo = subTipo.Correo,
                    IdTipoIncidente=subTipo.IdTipoIncidente
                };
                _dbContext.SubTipos.Add(dbSubtipo);
                await _dbContext.SaveChangesAsync();
                if (dbSubtipo.IdSubTipo!=0)
                {
                    responseApi.esCorrecto = true;
                    responseApi.Valor = dbSubtipo.IdSubTipo;
                }
                else
                {
                    responseApi.esCorrecto = false;
                    responseApi.Mensaje = "No guardado";
                }

                
            }
            catch (Exception ex)
            {
                responseApi.esCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(SubTipoDTO subTipo, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbSubtipo = await _dbContext.SubTipos.FirstOrDefaultAsync(p => p.IdSubTipo == id);
               
                if (dbSubtipo !=null)
                {
                    dbSubtipo.SubTipoIncidente = subTipo.SubTipoIncidente;
                    dbSubtipo.AreaEncargada = subTipo.AreaEncargada;
                    dbSubtipo.Correo = subTipo.Correo;
                    dbSubtipo.IdTipoIncidente= subTipo.IdTipoIncidente;

                    _dbContext.SubTipos.Update(dbSubtipo);
                    await _dbContext.SaveChangesAsync();

                    responseApi.esCorrecto = true;
                    responseApi.Valor = dbSubtipo.IdSubTipo;
                }
                else
                {
                    responseApi.esCorrecto = false;
                    responseApi.Mensaje = "Empleado no Encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.esCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbSubtipo = await _dbContext.SubTipos.FirstOrDefaultAsync(p => p.IdSubTipo == id);

                if (dbSubtipo != null)
                {
                    _dbContext.SubTipos.Remove(dbSubtipo);
                    await _dbContext.SaveChangesAsync();

                    responseApi.esCorrecto = true;
                }
                else
                {
                    responseApi.esCorrecto = false;
                    responseApi.Mensaje = "Empleado no Encontrado";
                }
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
