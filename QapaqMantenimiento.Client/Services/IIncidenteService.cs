using QapaqMantenimiento.Shared;
using System.Net.Http.Json;

namespace QapaqMantenimiento.Client.Services
{
    public interface IIncidenteService
    {
        Task<int> Guardar(IncidenteDTO incidenteDTO);
        Task<List<IncidenteDTO>> Lista();
    }
}
