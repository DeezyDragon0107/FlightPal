namespace FlightPal.Models
{
    public class Datos
    {
        public string? Nacionalidad { get; set; }
        public int Cedula { get; set; }
        public string? Fecha_nac { get; set; }
        public string? Rif { get; set; }
        public string? Primer_apellido { get; set; }
        public string? Segundo_apellido { get; set; }
        public string? Primer_nombre { get; set; }
        public string? Segundo_nombre { get; set; }
        public string? Request_date { get; set; }


    }

    public class Cedula
    {
        public bool Error { get; set; }
        public bool Error_str { get; set; }
        public Datos? Data { get; set; }
    }
}
