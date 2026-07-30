namespace FlightPal.Models.Entities
{
    public class ReservaPaquete
    { 
        public int Id_reservap { get; set; }
        public int Id_user { get; set; }
        public int Id_paquete { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto_total { get; set; }
        public string? Estado { get; set; }
        public string? Metodo_pago { get; set; } = "PAGO_MOVIL";
        public string? Numero_comprobante { get; set; }
        public byte[]? Imagen { get; set; }
        public string? Formato_imagen { get; set; }
        public int Personas { get; set; }
        public string? Nota { get; set; }
    }
}
