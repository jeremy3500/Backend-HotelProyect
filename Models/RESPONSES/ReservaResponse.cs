using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models.RESPONSES
{
    public class ReservaResponse
    {
        [JsonPropertyName("ID")] public int ID{ get; set; }
        [JsonPropertyName("FECHA_INICIO")] public DateTime FECHA_INICIO { get; set; }
        [JsonPropertyName("FECHA_FIN")] public DateTime FECHA_FIN { get; set; }
        [JsonPropertyName("ESTADO_RESERVA")] public string ESTADO_RESERVA { get; set; }
        [JsonPropertyName("MONTO_TOTAL")] public decimal MONTO_TOTAL { get; set; }
        [JsonPropertyName("NUMERO_HABITACION")] public string NUMERO_HABITACION { get; set; }
        [JsonPropertyName("TIPO_HABITACION")] public string TIPO_HABITACION { get; set; }
    }
}
