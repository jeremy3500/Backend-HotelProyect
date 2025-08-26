namespace Proyecto_Hoteleria.Models.DTOs
{
    public class HabitacionDTO
    {
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string tipo_habitacion { get; set; }
    }
    public class IdHabitacionDTO
    {
        public int id{ get; set; }
    }
}
