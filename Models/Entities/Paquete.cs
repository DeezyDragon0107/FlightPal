namespace FlightPal.Models.Entities
{
    public class Paquete
    {
        private DateTime _fecha_fin = DateTime.Now.AddDays(1);
        private DateTime _fecha_salida = DateTime.Now.AddDays(2);
        private DateTime _fecha_inicio = DateTime.Now;
        public int Id_Paquete { get; set; }
        public int Destino { get; set; }
        public string? Nombre_paquete { get; set; }
        public decimal Precio { get; set; }
        public string? Detalles { get; set; }
        public DateTime Fecha_inicio { get {
                return _fecha_inicio;
            } set {
                if (_fecha_fin <= value)
                {
                    _fecha_inicio = value;
                    Fecha_fin = _fecha_inicio.AddDays(1);
                }
                else
                {
                    _fecha_inicio = value;
                }
                if (_fecha_salida <= _fecha_fin)
                {
                    _fecha_salida = _fecha_fin.AddDays(1);
                }

            
            } } 

        public DateTime Fecha_fin { 
            get {
                return _fecha_fin;
            } 
            
            set {
                if (value <= Fecha_inicio)
                {
                    _fecha_fin = Fecha_inicio.AddDays(1);
                }
                else
                {
                    _fecha_fin = value;
                }
            
            } }

        public DateTime Fecha_salida
        {
            get
            {
                return _fecha_salida;
            }

            set
            {
                if (value <= Fecha_fin)
                {
                    _fecha_salida = Fecha_fin.AddDays(1);
                }
                else
                {
                    _fecha_salida = value;
                }

            }
        }

        public byte[]? Imagen { get; set; }
        public string? Formato_imagen { get; set; }
        public bool Todo_incluido { get; set; }
        public bool Hospedaje { get; set; }
        public bool Comida { get; set; }
        public bool Guia { get; set; }
        public bool Actividades { get; set; }
        public int Cupos_Disponibles { get; set; }
        public string? Estado { get; set; }

        public string GetImageUrl()
        {
            return $"data:{Formato_imagen};base64,{Convert.ToBase64String(Imagen)}";
        }
    }
}
