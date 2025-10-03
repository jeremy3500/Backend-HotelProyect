using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models.DTOs
{
    public class ReservaDTO
    {
        [JsonPropertyName("ID_USUARIO")] public int ID_USUARIO { get; set; }
    }

    public class InsertReservaDTO
    {
        [JsonPropertyName("ID_USUARIO")] public int ID_USUARIO { get; set; }
        [JsonPropertyName("ID_HABITACION")] public int ID_HABITACION { get; set; }
        [JsonPropertyName("FECHA_INICIO")] public DateTime FECHA_INICIO { get; set; }
        [JsonPropertyName("FECHA_FIN")] public DateTime FECHA_FIN { get; set; }
    }
    public class ModificarReservaDTO
    {
        [JsonPropertyName("ID_RESERVA")] public int ID_RESERVA { get; set; }
        [JsonPropertyName("ESTADO_RESERVA")] public int ESTADO_RESERVA_ID { get; set; }
    }
}
