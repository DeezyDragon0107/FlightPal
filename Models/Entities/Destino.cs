using System;

namespace FlightPal.Models.Entities
{
    public class Destino
    {
        public int Id_destino { get; set; }
        public int Id_pais { get; set; }

        public string? Nombre_destino { get; set; }
        public byte[]? Imagen {  get; set; }
        public string? Formato_imagen { get; set; }
        public bool Estado { get; set; }
        public string? Descripcion { get; set; }


        public string GetImageUrl()
        {
            return  $"data:{Formato_imagen};base64,{Convert.ToBase64String(Imagen)}";
        }
    }
}
