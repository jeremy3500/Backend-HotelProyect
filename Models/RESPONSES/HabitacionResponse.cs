using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models.RESPONSES
{
    public class HabitacionResponse
    {
        [JsonPropertyName("ID")] public int ID { get; set; }
        [JsonPropertyName("NUMERO_HABITACION")] public string NUMERO_HABITACION { get; set; }
        [JsonPropertyName("TIPO_HABITACION")] public string TIPO_HABITACION { get; set; }
        [JsonPropertyName("PRECIO_NOCHE")] public decimal PRECIO_NOCHE { get; set; }
        [JsonPropertyName("DESCRIPCION")] public string DESCRIPCION { get; set; }
    }
    public class HabitacionReservadoResponse
    {
        [JsonPropertyName("ID")] public int ID { get; set; }
    }

    public class HabitacionPrecioResponse
    {
        [JsonPropertyName("PRECIO_NOCHE")] public decimal PRECIO_NOCHE { get; set; }
    }

}
