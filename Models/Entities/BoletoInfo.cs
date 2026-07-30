using QRCoder;
namespace FlightPal.Models.Entities
{
    public class BoletoInfo
    {
        public int Id_reserva { get; set; }
        public int Id_user { get; set; }
        public int Id_vuelo { get; set; }
        public int Id_boleto { get; set; }
        public int Id_aerolinea { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public char Nacionalidad { get; set; }
        public string Dni { get; set; }
        public int Destino { get; set; }
        public int Origen { get; set; }
        public DateTime Fecha_llegada { get; set; }
        public DateTime Fecha_salida { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public string? Nombre_aerolinea { get; set; }
        public string? Abreviatura { get; set; }
        public byte[]? Imagen { get; set; }
        public string? Tipo_imagen { get; set; }
        public bool Check { get; set; }
        public string? Color { get; set;}
        public int Adultos { get; set; }
        public int Ninos { get; set; }

        public string GetImageUrl()
        {
            return $"data:{Tipo_imagen};base64,{Convert.ToBase64String(Imagen)}";
        }

        public string? ColorDegradado()
        {
            int R = Convert.ToInt32(Color?.Substring(1, 2) ?? "0", 16);
            int G = Convert.ToInt32(Color?.Substring(3, 2) ?? "0", 16);
            int B = Convert.ToInt32(Color?.Substring(5, 2) ?? "0", 16);

            R = R + 60 > 255 ? 255 : R + 60;
            G = G + 60 > 255 ? 255 : G + 60;
            B = B + 60 > 255 ? 255 : B + 60;
            Color = $"#{R.ToString("X2")}{G.ToString("X2")}{B.ToString("X2")}";
            return Color;
        }

        public string? ColorDegradadoOscuro()
        {
            int R = Convert.ToInt32(Color?.Substring(1, 2) ?? "0", 16);
            int G = Convert.ToInt32(Color?.Substring(3, 2) ?? "0", 16);
            int B = Convert.ToInt32(Color?.Substring(5, 2) ?? "0", 16);

            R = R - 60 < 0 ? 0 : R - 60;
            G = G - 60 < 0 ? 0 : G - 60;
            B = B - 60 < 0 ? 0 : B - 60;
            Color = $"#{R.ToString("X2")}{G.ToString("X2")}{B.ToString("X2")}";
            return Color;
        }

        public string? GetQr()
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData data = generator.CreateQrCode($"{Abreviatura}{Id_boleto.ToString().PadLeft(5, '0')}", QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode bitmap = new BitmapByteQRCode(data);
            byte[] buffer = bitmap.GetGraphic(20);
            var ms = new MemoryStream(buffer);
            
            return $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
        }
    }
}
