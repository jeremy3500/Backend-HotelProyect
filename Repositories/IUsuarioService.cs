using Proyecto_Hoteleria.Models;
using Proyecto_Hoteleria.Models.DTOs;
using Proyecto_Hoteleria.Models.RESPONSES;

namespace Proyecto_Hoteleria.Repositories
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> GetUsuariosListAsync();
        public Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(int UsuarioId);
        public Task<List<Usuario>> Register(UsuarioDTO usuario);

        public Task<List<Usuario>> Login(LoginDTO usuario);

        public Task<IEnumerable<ReservaResponse>> GetReservas(int id_usuario);
        public Task<List<HabitacionReservadoResponse>> GetHabitacionesReservados(HabitacionDTO habitacion);
        public Task<List<HabitacionResponse>> GetHabitaciones(HabitacionDTO habitacion);
        public Task<List<HabitacionResponse>> GetPrecioNoche(int id);
        public Task<List<ReservaResponse>> InsertReserva(InsertReservaDTO InsReserva, decimal precio);
        public Task<List<Reserva>> GetReservasListAdm();
        public Task<IEnumerable<ReservaResponse>> ModificarReserva(ModificarReservaDTO reserva);
        public Task<IEnumerable<DashboardResponse>> GetDataDashboard();
        public Task<List<DatosGraficResponse>> GetDataGrafic();
    }
}
