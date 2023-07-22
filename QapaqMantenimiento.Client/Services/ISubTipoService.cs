using QapaqMantenimiento.Shared;

namespace QapaqMantenimiento.Client.Services
{
    public interface ISubTipoService
    {
        Task<List<SubTipoDTO>> Lista();
        Task<SubTipoDTO> Buscar(int id);
        Task<int> Guardar(SubTipoDTO subTipo);
        Task<int> Editar(SubTipoDTO subTipo);
        Task<bool> Eliminar(int id);
    }
}
