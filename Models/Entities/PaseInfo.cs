using QRCoder;

namespace FlightPal.Models.Entities
{
    public class PaseInfo
    {
        public int Id_pase {  get; set; }
        public int Id_reserva_p { get; set; }
        public int Id_user { get; set; }
        public int Id_paquete { get; set; }
        public bool Check { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }
        public string? Nacionalidad { get; set; }
        public int Personas { get; set; }
        public byte[]? Imagen {  get; set; }
        public string? Formato_imagen { get; set; }
        public string? Nombre_destino { get; set; }
        public string? Nombre_paquete { get; set; }
        public DateTime Fecha_salida { get; set; }
        public decimal Monto_total { get; set; }

        public string GetQr()
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData data = generator.CreateQrCode($"PCK-{Id_reserva_p.ToString().PadLeft(5, '0')}-{Id_pase}", QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode bitmap = new BitmapByteQRCode(data);
            byte[] buffer = bitmap.GetGraphic(20);
            var ms = new MemoryStream(buffer);

            return $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
        }

    }
}
