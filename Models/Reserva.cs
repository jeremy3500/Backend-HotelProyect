using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models
{
    
    public class Reserva
    {
        [JsonPropertyName("ID")] public int ID { get; set; }
        [JsonPropertyName("CLIENTE")] public string CLIENTE { get; set; }
        [JsonPropertyName("NRO_DOCUMENTO")] public string NRO_DOCUMENTO { get; set; }
        [JsonPropertyName("NUMERO_HABITACION")] public string NUMERO_HABITACION { get; set; }
        [JsonPropertyName("FECHA_INICIO")] public DateTime FECHA_INICIO { get; set; }
        [JsonPropertyName("FECHA_FIN")] public DateTime FECHA_FIN { get; set; }
        [JsonPropertyName("MONTO_TOTAL")] public decimal MONTO_TOTAL { get; set; }
        [JsonPropertyName("ESTADO_RESERVA")] public string ESTADO_RESERVA { get; set; }
    }
}
