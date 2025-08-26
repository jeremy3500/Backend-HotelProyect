namespace Proyecto_Hoteleria.Models.RESPONSES
{
    public class HabitacionResponse
    {
        public int id { get; set; }
        public int numero_habitacion { get; set; }
        public string tipo_habitacion { get; set; }
        public decimal precio_noche { get; set; }
        public string descripcion { get; set; }
    }
    public class HabitacionReservadoResponse
    {
        public int id { get; set; }
    }

    public class HabitacionPrecioResponse
    {
        public decimal precio_noche { get; set; }
    }

}
