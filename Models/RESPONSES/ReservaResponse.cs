namespace Proyecto_Hoteleria.Models.RESPONSES
{
    public class ReservaResponse
    {
        public int id{ get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string estado_reserva { get; set; }
        public decimal monto_total { get; set; }
        public int numero_habitacion { get; set; }
        public string tipo_habitacion { get; set; }
    }
}
