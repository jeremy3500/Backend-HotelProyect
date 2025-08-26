using Microsoft.Data.SqlClient;
using Proyecto_Hoteleria.Models;
using Proyecto_Hoteleria.Models.RESPONSES;

public interface IDbContextWrapper
{
    Task<List<Usuario>> ExecuteUsuarioFromSqlRaw(string sql, params SqlParameter[] parameters);
    Task<List<ReservaResponse>> ExecuteReservaResponseFromSqlRaw(string sql, params SqlParameter[] parameters);
    Task<List<HabitacionReservadoResponse>> ExecuteHabitacionReservadoResponseFromSqlRaw(string sql, params SqlParameter[] parameters);
    Task<List<HabitacionResponse>> ExecuteHabitacionResponseFromSqlRaw(string sql, params SqlParameter[] parameters);
    Task<List<Reserva>> ExecuteReservaFromSqlRaw(string sql, params SqlParameter[] parameters);
    Task<List<DashboardResponse>> ExecuteDashboardResponseFromSqlRaw(string sql, params SqlParameter[] parameters);
    Task<List<DatosGraficResponse>> ExecuteDatosGraficResponseFromSqlRaw(string sql, params SqlParameter[] parameters);
}

