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
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        private readonly string endPoint = "empleadocom/v1/Usuario";
        private readonly string _backendUrl;


        public UsuarioService(HttpClient httpClient, IOptions<Settings> settings)
        {
            _httpClient = httpClient;
            _backendUrl = settings.Value.EmpleadoComBackend;
        }
        public string HashContrasenia(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return Convert.ToBase64String(salt) + ":" + hashed;
        }



        public async Task<LoginResponseModel> ValidarUsuario(string nombreUsuario, string contrasenia)
        {
            var response = await this.UsuarioPorNombreUsuario(nombreUsuario);
            if (response != null)
            {
                var esValidaContrasenia = VerificarContrasenia(contrasenia, response.Contrasenia);
                return esValidaContrasenia ? response : null;
            }
            return null ;
        }

        public async Task<LoginResponseModel> UsuarioPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<LoginResponseModel>($"{this._backendUrl}{endPoint}/PorNombreUsuario/{nombreUsuario}");
                return response;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<bool> RegisterUser(UsuarioModel user)
        {
            user.Contrasenia = HashContrasenia(user.Contrasenia);
            var userJson = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(this._backendUrl + endPoint, userJson);

            return response.IsSuccessStatusCode;
        }

        public bool VerificarContrasenia(string enteredPassword, string storedPassword)
        {
            var parts = storedPassword.Split(':');
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = parts[1];

            string enteredHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return enteredHash == storedHash;
        }
    }

}
