using FlightPal.Models;
namespace FlightPal.Services
{
    public interface ICedulaService
    {
        public Task<Cedula?> GetCedula(string numCedula, string nacionalidad);
    }
}
