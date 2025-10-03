using System.Text.Json.Serialization;

namespace Proyecto_Hoteleria.Models.DTOs
{
    public class LoginDTO
    {
        [JsonPropertyName("EMAIL_DOCUMENTO")] public string EMAIL_DOCUMENTO { get; set; }
        [JsonPropertyName("PASSWORD")] public string PASSWORD { get; set; }
    }
}
