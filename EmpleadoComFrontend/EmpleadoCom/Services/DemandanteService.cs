using EmpleadoComFrontend.Config;
using EmpleadoComFrontend.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmpleadoComFrontend.Services
{
    public class DemandanteService
    {
        private readonly HttpClient _httpClient;
        private readonly string endPoint = "empleadocom/v1/Demandante";
        private readonly string _backendUrl;


        public DemandanteService(HttpClient httpClient, IOptions<Settings> settings)
        {
            _httpClient = httpClient;
            _backendUrl = settings.Value.EmpleadoComBackend;
        }


        public async Task<bool> CrearPerfil(DemandanteModel demandante)
        {
            var userJson = new StringContent(
                JsonSerializer.Serialize(demandante),
                Encoding.UTF8,
                "application/json");

            var response =  _httpClient.PostAsync(this._backendUrl + endPoint, userJson).Result;

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ActualizarPerfil(DemandanteModel demandante)
        {
            var userJson = new StringContent(
                JsonSerializer.Serialize(demandante),
                Encoding.UTF8,
                "application/json");

            var response = _httpClient.PutAsync(this._backendUrl + endPoint, userJson).Result;

            return response.IsSuccessStatusCode;
        }

        public async Task<DemandanteModel> GetPerfilPorId(int id)
        {
            var demandante  = await _httpClient.GetFromJsonAsync<DemandanteModel>(this._backendUrl + endPoint + "/" + id);
            return demandante;
        }
    }

}
