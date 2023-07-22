using QapaqMantenimiento.Shared;
using System.Net.Http.Json;

namespace QapaqMantenimiento.Client.Services
{
    public class TipoIncidenteService:ITipoIncidenteService 
    {
        private readonly HttpClient _http;

        public TipoIncidenteService(HttpClient http)
        {
            _http = http;               
        }

        public async Task<List<TipoIncidenteDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TipoIncidenteDTO>>>("api/TipoIncidente/Lista");

            if (result!.esCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
