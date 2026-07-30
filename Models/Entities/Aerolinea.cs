namespace FlightPal.Models.Entities
{
    public class Aerolinea
    {
        public string? Id_aerolinea { get; set; }
        public string? Nombre_aerolinea { get; set; }

        public bool Activo { get; set; }
        public bool Internacional { get; set; }
        public string? Abreviatura { get; set; }

        public int Id_pais { get; set; }
        public DateTime Fecha_contrato { get; set; } = DateTime.Now;

        public string? Contacto { get; set; }

        public double Porcentaje { get; set; } = 5;

        public byte[]? Imagen { get; set; }

        public string? Tipo_imagen { get; set; }

        public string? Color { get; set; }

        public string? ColorDegradado()
        {
            int R = Convert.ToInt32(Color?.Substring(1, 2) ?? "0", 16);
            int G = Convert.ToInt32(Color?.Substring(3, 2) ?? "0", 16);
            int B = Convert.ToInt32(Color?.Substring(5, 2) ?? "0", 16);
            
            R = R+60 > 255 ? 255 : R + 60;
            G = G+60 > 255 ? 255 : G + 60;
            B = B+60 > 255 ? 255 : B + 60;
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

        public string GetImageUrl()
        {
            return $"data:{Tipo_imagen};base64,{Convert.ToBase64String(Imagen)}";
        }

    }
}
