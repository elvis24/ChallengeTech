using QapaqMantenimiento.Shared;
using System.Net.Http.Json;

namespace QapaqMantenimiento.Client.Services
{
    public class SubTipoService:ISubTipoService
    {
        private readonly HttpClient _http;

        public SubTipoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SubTipoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<SubTipoDTO>>>("api/SubTipo/Lista");

            if (result!.esCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<SubTipoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<SubTipoDTO>>($"api/SubTipo/Buscar/{id}");

            if (result!.esCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Editar(SubTipoDTO subTipo)
        {
            var result = await _http.PutAsJsonAsync($"api/SubTipo/Editar/{subTipo.IdSubTipo}", subTipo);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.esCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/SubTipo/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.esCorrecto)
                return response.esCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Guardar(SubTipoDTO subTipo)
        {
            var result = await _http.PostAsJsonAsync("api/SubTipo/Guardar", subTipo);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.esCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }
    }
}
