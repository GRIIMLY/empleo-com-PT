using EmpleadoComFrontend.Config;
using EmpleadoComFrontend.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Runtime;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmpleadoComFrontend.Services
{
    public class HabilidadUsuarioTrabajoService
    {
        private readonly HttpClient _httpClient;
        private readonly string endPoint = "empleadocom/v1/HabilidadUsuarioTrabajo";
        private readonly string _backendUrl;


        public HabilidadUsuarioTrabajoService(HttpClient httpClient, IOptions<Settings> settings)
        {
            _httpClient = httpClient;
            _backendUrl = settings.Value.EmpleadoComBackend;
        }

        public async Task<bool> RegistrarListadoHabilidadUsuarioTrabajo(List<HabilidadUsuarioTrabajoModel> habilidadesSeleccionadas)
        {
            var habilidadesJson = new StringContent(
                JsonSerializer.Serialize(habilidadesSeleccionadas),
                Encoding.UTF8,
                "application/json");

            var response =  _httpClient.PostAsync(this._backendUrl + endPoint+ "/all", habilidadesJson).Result;

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteHabilidadPorIdUsuario(int IdUsuario)
        {
            var response = _httpClient.DeleteAsync(this._backendUrl + endPoint + "/DeleteHabilidadPorIdUsuario/"+ IdUsuario).Result;

            return response.IsSuccessStatusCode;
        }
    }

}
