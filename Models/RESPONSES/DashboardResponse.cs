namespace Proyecto_Hoteleria.Models.RESPONSES
{
    public class DashboardResponse
    {
        public int Id { get; set; }
        public int Individual { get; set; }
        public int Doble { get; set; }
        public int Suit { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Ingresos_pendientes { get; set; }

        public int Cant_clientes { get; set; }
        public int Reservas_en_proceso { get; set; }
        public int Reservas_pendientes { get; set; }
    }

    public class DatosGraficResponse
    {
        public int Id { get; set; }
        public int Reservado { get; set; }
        public int procesado { get; set; }
        
    }
}
