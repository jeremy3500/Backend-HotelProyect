using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models.RESPONSES
{
    public class DashboardResponse
    {
        [JsonPropertyName("ID")] public int ID { get; set; }
        [JsonPropertyName("INDIVIDUAL")] public int INDIVIDUAL { get; set; }
        [JsonPropertyName("DOBLE")] public int DOBLE { get; set; }
        [JsonPropertyName("FAMILIAR")] public int FAMILIAR { get; set; }
        [JsonPropertyName("SUIT")] public int SUIT { get; set; }

        [JsonPropertyName("INGRESOS")] public decimal INGRESOS { get; set; }
        [JsonPropertyName("INGRESOS_PENDIENTES")] public decimal INGRESOS_PENDIENTES { get; set; }

        [JsonPropertyName("CANT_CLIENTES")] public int CANT_CLIENTES { get; set; }
        [JsonPropertyName("RESERVAS_EN_PROCESO")] public int RESERVAS_EN_PROCESO { get; set; }
        [JsonPropertyName("RESERVAS_PENDIENTES")] public int RESERVAS_PENDIENTES { get; set; }
    }

    public class DatosGraficResponse
    {
        [JsonPropertyName("ID")] public int ID { get; set; }
        [JsonPropertyName("RESERVADO")] public int RESERVADO { get; set; }
        [JsonPropertyName("PROCESADO")] public int PROCESADO { get; set; }
        
    }
}
