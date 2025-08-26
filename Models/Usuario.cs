namespace Proyecto_Hoteleria.Models
{
    
    public class Usuario
    {
        public int Id { get; set; }
        public int Id_Perfil { get; set; }
        public string Nombres { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string Dni { get; set; }
    }
}
