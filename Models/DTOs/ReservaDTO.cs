namespace Proyecto_Hoteleria.Models.DTOs
{
    public class ReservaDTO
    {
        public int id_usuario { get; set; }
    }

    public class InsertReservaDTO
    {
        public int id_usuario { get; set; }
        public int id_habitacion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
    }
    public class ModificarReservaDTO
    {
        public int id_reserva { get; set; }
        public string estado_reserva { get; set; }
    }
}
