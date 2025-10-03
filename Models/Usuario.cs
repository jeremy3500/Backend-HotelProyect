using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models
{


    public class Usuario
    {
        [JsonPropertyName("ID")] public int ID { get; set; }
        [JsonPropertyName("ID_PERFIL")] public int ID_PERFIL { get; set; }
        [JsonPropertyName("NOMBRES")] public string NOMBRES { get; set; }
        [JsonPropertyName("TIPO_DOCUMENTO")] public string TIPO_DOCUMENTO { get; set; }
        [JsonPropertyName("DOCUMENTO")] public string DOCUMENTO { get; set; }
        [JsonPropertyName("EMAIL")] public string EMAIL { get; set; }
        [JsonPropertyName("PASSWORD")] public string PASSWORD { get; set; }
        [JsonPropertyName("FECHA_REGISTRO")] public DateTime FECHA_REGISTRO { get; set; }
    }
}
