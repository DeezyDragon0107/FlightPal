using System.ComponentModel.DataAnnotations;

namespace FlightPal.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(AllowEmptyStrings =false ,ErrorMessage = "El campo Nombre es obligatorio.")]
        
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El campo Nombre no puede exceder los 20 caracteres.")]
        public string? Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo Apellido es obligatorio.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El campo Apellido no puede exceder los 20 caracteres.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El campo Teléfono no es válido.")]
        public string? CellPhone { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
        [DataType(DataType.Date, ErrorMessage = "El campo Fecha de Nacimiento no es válido.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El campo Dirección no puede exceder los 50 caracteres.")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "El campo País es obligatorio.")]
        [RegularExpression("^[A-Z]{1}$", ErrorMessage = "El campo País debe ser una letra mayúscula.")]
        public char Country { get; set; }
        [Required(ErrorMessage = "El campo DNI es obligatorio.")]
        [Range(1, 99999999, ErrorMessage = "El campo DNI debe estar entre 1 y 99.999.999.")]
        public int Dni { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email no es válido.")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; } 
    }
}
