using FlightPal.Models;

namespace FlightPal.Services
{
    public interface IDolarService
    {
        public Task<Dolar> GetDolarAsync();
    }

    public class DolarService : IDolarService
    {

        private readonly HttpClient _httpClient;
       
        public DolarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
          
        }

        public async Task<Dolar> GetDolarAsync()
        {
           
                return new Dolar() { Promedio = 361.50};
            
        }
    }
}
