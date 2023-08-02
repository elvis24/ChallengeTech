using QapaqMantenimiento.Shared;
using System.Net.Http.Json;

namespace QapaqMantenimiento.Client.Services
{
    public class IncidenteService:IIncidenteService
    {
        private readonly HttpClient _http;

        public IncidenteService(HttpClient http)
        {
            _http = http;
        }
        public async Task<int> Guardar(IncidenteDTO incidenteDTO)
        {
            var result = await _http.PostAsJsonAsync("api/Incidente/Guardar", incidenteDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.esCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<List<IncidenteDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<IncidenteDTO>>>("api/Incidente/Lista");

            if (result!.esCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
