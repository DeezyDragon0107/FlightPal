using System.ComponentModel.DataAnnotations;

namespace FlightPal.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "La dirección de correo electónico es requerida")]
        public string? Email { get ; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La contraseña es requerida")]
        public string? Password { get ; set; }
    }
}
