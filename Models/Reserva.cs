namespace Proyecto_Hoteleria.Models
{
    
    public class Reserva
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Dni { get; set; }
        public int numero_habitacion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public decimal Monto_total { get; set; }
        public string Estado { get; set; }
    }
}
