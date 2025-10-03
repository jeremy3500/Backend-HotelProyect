using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models.DTOs
{
    public class HabitacionDTO
    {
        [JsonPropertyName("FECHA_INICIO")] public DateTime FECHA_INICIO { get; set; }
        [JsonPropertyName("FECHA_FIN")] public DateTime FECHA_FIN { get; set; }
        [JsonPropertyName("TIPO_HABITACION_ID")] public int TIPO_HABITACION_ID { get; set; }
    }
    public class IdHabitacionDTO
    {
        public int id{ get; set; }
    }
}
