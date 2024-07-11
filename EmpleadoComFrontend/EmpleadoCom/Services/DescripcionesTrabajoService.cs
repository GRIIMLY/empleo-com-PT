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
    public class DescripcionesTrabajoService
    {
        private readonly HttpClient _httpClient;
        private readonly string endPoint = "empleadocom/v1/DescripcionesTrabajo";
        private readonly string _backendUrl;


        public DescripcionesTrabajoService(HttpClient httpClient, IOptions<Settings> settings)
        {
            _httpClient = httpClient;
            _backendUrl = settings.Value.EmpleadoComBackend;
        }

        public async Task<List<DescripcionTrabajoModel>> GetResumenDescripcionTrabajo()
        {
       
            var response =  _httpClient.GetFromJsonAsync<List<DescripcionTrabajoModel>>(this._backendUrl + endPoint+ "/GetResumenDescripcionTrabajo").Result;

            return response;
        }

    }

}
