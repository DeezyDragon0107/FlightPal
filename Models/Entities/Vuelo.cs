namespace FlightPal.Models.Entities
{
    public class Vuelo
    {
        public int Id_vuelo { get; set; }

        public string? Id_aerolinea { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public DateTime Fecha_salida { get; set; }
        public DateTime Fecha_llegada { get; set; }
        public int Duracion { get; set; }
        public decimal Precio { get; set; }
        public string? Estado { get; set; }
        public string? Tipo_Vuelo { get; set; } = "DIRECTO";
        public bool Internacional { get; set; }
        public int Asientos { get; set; }
    }
}
