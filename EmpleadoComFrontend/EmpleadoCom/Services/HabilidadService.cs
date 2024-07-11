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
    public class HabilidadService
    {
        private readonly HttpClient _httpClient;
        private readonly string endPoint = "empleadocom/v1/Habilidad";
        private readonly string _backendUrl;


        public HabilidadService(HttpClient httpClient, IOptions<Settings> settings)
        {
            _httpClient = httpClient;
            _backendUrl = settings.Value.EmpleadoComBackend;
        }

        public async Task<List<HabilidadModel>> GetHabilidades()
        {
            return await _httpClient.GetFromJsonAsync<List<HabilidadModel>>(this._backendUrl + endPoint);
        }

        public async Task<List<HabilidadModel>> GetHabilidadesPorIdUsuario(int IdUsuario)
        {
            var url = this._backendUrl + endPoint + "/PorIdUsuario/" + IdUsuario;
            return await _httpClient.GetFromJsonAsync<List<HabilidadModel>>(url);
        }
        public async Task<List<HabilidadModel>> GetHabilidadesPorPorIdTabajo(int IdTabajo)
        {
            return await _httpClient.GetFromJsonAsync<List<HabilidadModel>>(this._backendUrl + endPoint + "/PorIdTabajo/" + IdTabajo);
        }


    }

}
