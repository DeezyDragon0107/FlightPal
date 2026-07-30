namespace FlightPal.Models.Entities
{
    public class Reserva
    {
        public int Id_reserva { get; set; }
        public int Id_user { get; set; }
        public int Id_vuelo { get; set; }
        public DateTime Fecha_reserva { get; set; } = DateTime.Now;
        public string? Estado {  get; set; }
        public double Total { get; set; }
        public string? Metodo_pago { get; set; } = "PAGO_MOVIL";
        public string? Num_comprobante { get; set; }
        public byte[]? Imagen_comprobante { get; set; }
        public string? Formato_imagen { get; set; }
        public decimal Monto_total { get; set; }
        public int Adultos { get; set; }
        public int Ninos { get; set; }

    }
}
