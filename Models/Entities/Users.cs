namespace FlightPal.Models.Entities
{
    public class Users
    {
        public int Id_user { get; set; }
        public string? Nombre { get; set; }

        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }

        public string? Apellido { get; set; }

        public int Dni { get; set; }
        public char Nacionalidad { get; set; }
        public DateTime Fecha_registro { get; set; }
        public bool Estado { get; set; }
        public override string? ToString()
        {
            return $"Id_user: {Id_user}, UserName: {Nombre}, Role: {Role}";
        }
    }
}
