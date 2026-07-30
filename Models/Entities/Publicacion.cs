using ApexCharts;
using System.Collections.Generic;

namespace FlightPal.Models.Entities
{
    public class Publicacion
    {

        public int Id_post { get; set; } 
        public string? Titulo { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public DateTime Fecha_publicacion { get; set; } 
        public string? Imagen_url { get; set; }
        public string? Categoria { get; set; } = "NOTICIA";
    }
}
