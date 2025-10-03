using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models.DTOs
{
    public class UsuarioDTO
    {
        [JsonPropertyName("ID_PERFIL")] public int ID_PERFIL { get; set; }
        [JsonPropertyName("NOMBRES")] public string NOMBRES { get; set; }
        [JsonPropertyName("APELLIDOS")] public string APELLIDOS { get; set; }
        [JsonPropertyName("TELEFONO")] public string TELEFONO { get; set; }
        [JsonPropertyName("TIPO_DOCUMENTO_ID")] public int TIPO_DOCUMENTO_ID { get; set; }
        [JsonPropertyName("DOCUMENTO")] public string DOCUMENTO { get; set; }
        [JsonPropertyName("EMAIL")] public string EMAIL { get; set; }
        [JsonPropertyName("PASSWORD")] public string PASSWORD { get; set; }
    }
}
