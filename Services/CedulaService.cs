using FlightPal.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace FlightPal.Services
{
    public class CedulaService : ICedulaService
    {

        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apisettings;
        public CedulaService(HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apisettings = apiSettings;
        }

        public async Task<Cedula?> GetCedula(string numCedula, string nacionalidad)
        {
            var url = $"{_apisettings.CedulaApi.BaseUrl}?" + $"app_id={_apisettings.CedulaApi.AppId}&token={_apisettings.CedulaApi.Token}&nacionalidad={nacionalidad}&cedula={numCedula}";
          
            try
            {
                
                return await _httpClient.GetFromJsonAsync<Cedula>(url);
            }
            catch (Exception ex)
            {
             
                Console.WriteLine($"Error al obtener cédula: {ex.Message}");
                return null;
            }
        }
    }
}
