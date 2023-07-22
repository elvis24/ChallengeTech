using QapaqMantenimiento.Shared;

namespace QapaqMantenimiento.Client.Services
{
    public interface ITipoIncidenteService
    {
        Task<List<TipoIncidenteDTO>> Lista();
    }
}
