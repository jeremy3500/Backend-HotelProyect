using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Proyecto_Hoteleria.Models.RESPONSES;
using Proyecto_Hoteleria.Models;

public class DbContextWrapper : IDbContextWrapper
{
    private readonly DbContextClass _context;

    public DbContextWrapper(DbContextClass context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> ExecuteUsuarioFromSqlRaw(string sql, params SqlParameter[] parameters)
    {
        return await _context.Usuario.FromSqlRaw(sql, parameters).ToListAsync();
    }

    public async Task<List<ReservaResponse>> ExecuteReservaResponseFromSqlRaw(string sql, params SqlParameter[] parameters)
    {
        return await _context.ReservaResponse.FromSqlRaw(sql, parameters).ToListAsync();
    }

    public async Task<List<HabitacionReservadoResponse>> ExecuteHabitacionReservadoResponseFromSqlRaw(string sql, params SqlParameter[] parameters)
    {
        return await _context.HabitacionReservadoResponse.FromSqlRaw(sql, parameters).ToListAsync();
    }

    public async Task<List<HabitacionResponse>> ExecuteHabitacionResponseFromSqlRaw(string sql, params SqlParameter[] parameters)
    {
        return await _context.HabitacionResponse.FromSqlRaw(sql, parameters).ToListAsync();
    }

    public async Task<List<Reserva>> ExecuteReservaFromSqlRaw(string sql, params SqlParameter[] parameters)
    {
        return await _context.Reserva.FromSqlRaw(sql, parameters).ToListAsync();
    }

    public async Task<List<DashboardResponse>> ExecuteDashboardResponseFromSqlRaw(string sql, params SqlParameter[] parameters)
    {
        return await _context.DashboardResponse.FromSqlRaw(sql, parameters).ToListAsync();
    }

    public async Task<List<DatosGraficResponse>> ExecuteDatosGraficResponseFromSqlRaw(string sql, params SqlParameter[] parameters)
    {
        return await _context.DatosGraficResponse.FromSqlRaw(sql, parameters).ToListAsync();
    }
}

