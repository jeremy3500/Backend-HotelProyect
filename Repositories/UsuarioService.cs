using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proyecto_Hoteleria.Models;
using Proyecto_Hoteleria.Models.DTOs;
using Proyecto_Hoteleria.Models.RESPONSES;

namespace Proyecto_Hoteleria.Repositories
{
   

    public class UsuarioService : IUsuarioService
    {
        private readonly DbContextClass _dbContext;


        private readonly IDbContextWrapper _dbWrapper;

      
        public UsuarioService(IDbContextWrapper dbWrapper)
        {
            _dbWrapper = dbWrapper;
        }

        public async Task<List<Usuario>> GetUsuariosListAsyncT()
        {
            return await _dbWrapper.ExecuteUsuarioFromSqlRaw("SP_GetUsuarioList");
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioByIdAsyncT(int UsuarioId)
        {
            var param = new SqlParameter("@UsuarioId", UsuarioId);
            return await _dbWrapper.ExecuteUsuarioFromSqlRaw("exec SP_GetUsuarioByID @UsuarioId", param);
        }

        public async Task<List<Usuario>> RegisterT(UsuarioDTO usuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id_Perfil", 2),
                new SqlParameter("@Nombres", usuario.Nombre),
                new SqlParameter("@Contraseña", usuario.Clave),
                new SqlParameter("@Email", usuario.Correo),
                new SqlParameter("@Dni", usuario.Dni)
            };

            return await _dbWrapper.ExecuteUsuarioFromSqlRaw("exec SP_InsertUsuario @Id_Perfil, @Nombres, @Contraseña, @Email, @Dni", parameters);
        }

        public async Task<List<Usuario>> LoginT(LoginDTO usuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@Email", usuario.Correo),
                new SqlParameter("@Contraseña", usuario.Clave)
            };

            return await _dbWrapper.ExecuteUsuarioFromSqlRaw("exec SP_LoggerUsuario @Email, @Contraseña", parameters);
        }

        public async Task<IEnumerable<ReservaResponse>> GetReservasT(int id_usuario)
        {
            var param = new SqlParameter("@id_usuario", id_usuario);
            return await _dbWrapper.ExecuteReservaResponseFromSqlRaw("exec SP_GetReservasPorUsuario @id_usuario", param);
        }

        public async Task<List<HabitacionReservadoResponse>> GetHabitacionesReservadosT(HabitacionDTO habitacion)
        {
            var parameters = new[]
            {
                new SqlParameter("@fecha_inicio", habitacion.fecha_inicio),
                new SqlParameter("@fecha_fin", habitacion.fecha_fin),
                new SqlParameter("@tipo_habitacion", habitacion.tipo_habitacion)
            };

            return await _dbWrapper.ExecuteHabitacionReservadoResponseFromSqlRaw("exec SP_GetHabitacionReservInFech @fecha_inicio, @fecha_fin, @tipo_habitacion", parameters);
        }

        public async Task<List<HabitacionResponse>> GetHabitacionesT(HabitacionDTO habitacion)
        {
            var param = new SqlParameter("@tipo_habitacion", habitacion.tipo_habitacion);
            return await _dbWrapper.ExecuteHabitacionResponseFromSqlRaw("exec SP_GetHabitacionPorTipo @tipo_habitacion", param);
        }

        public async Task<List<HabitacionResponse>> GetPrecioNocheT(int id)
        {
            var param = new SqlParameter("@id_habitacion", id);
            return await _dbWrapper.ExecuteHabitacionResponseFromSqlRaw("exec SP_GetDataHabit @id_habitacion", param);
        }

        public async Task<List<ReservaResponse>> InsertReservaT(InsertReservaDTO reserva, decimal precio)
        {
            var parameters = new[]
            {
                new SqlParameter("@id_usuario", reserva.id_usuario),
                new SqlParameter("@id_habitacion", reserva.id_habitacion),
                new SqlParameter("@fecha_inicio", reserva.fecha_inicio),
                new SqlParameter("@fecha_fin", reserva.fecha_fin),
                new SqlParameter("@estado_reserva", "Pendiente"),
                new SqlParameter("@monto_total", precio)
            };

            return await _dbWrapper.ExecuteReservaResponseFromSqlRaw("exec SP_InsertReserva @id_usuario, @id_habitacion, @fecha_inicio, @fecha_fin, @estado_reserva, @monto_total", parameters);
        }

        public async Task<List<Reserva>> GetReservasListAdmT()
        {
            return await _dbWrapper.ExecuteReservaFromSqlRaw("SP_GetReservasList");
        }

        public async Task<IEnumerable<ReservaResponse>> ModificarReservaT(ModificarReservaDTO reserva)
        {
            var parameters = new[]
            {
                new SqlParameter("@id_reserva", reserva.id_reserva),
                new SqlParameter("@estado_reserva", reserva.estado_reserva)
            };

            return await _dbWrapper.ExecuteReservaResponseFromSqlRaw("exec SP_ModificReserva @id_reserva, @estado_reserva", parameters);
        }

        public async Task<IEnumerable<DashboardResponse>> GetDataDashboardT()
        {
            return await _dbWrapper.ExecuteDashboardResponseFromSqlRaw("SP_GetDatosParaDashboard");
        }

        public async Task<List<DatosGraficResponse>> GetDataGraficT()
        {
            return await _dbWrapper.ExecuteDatosGraficResponseFromSqlRaw("SP_GetDataGrafico");
        }


        public UsuarioService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<List<Usuario>> GetUsuariosListAsync()
        {
            return await _dbContext.Usuario
                .FromSqlRaw<Usuario>("SP_GetUsuarioList")
            .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(int UsuarioId)
        {
            var param = new SqlParameter("@UsuarioId", UsuarioId);

            var UsuarioDetails = await Task.Run(() => _dbContext.Usuario
                .FromSqlRaw(@"exec SP_GetUsuarioByID @UsuarioId", param).ToListAsync());
            return UsuarioDetails;
        }

        public async Task<List<Usuario>> Register (UsuarioDTO usuario)
        {
            var paraneter = new List<SqlParameter>();
            paraneter.Add(new SqlParameter("@Id_Perfil", 2));
            paraneter.Add(new SqlParameter("@Nombres", usuario.Nombre));
            paraneter.Add(new SqlParameter("@Contraseña", usuario.Clave));
            paraneter.Add(new SqlParameter("@Email", usuario.Correo));
            paraneter.Add(new SqlParameter("@Dni", usuario.Dni));

            return await _dbContext.Usuario
                .FromSqlRaw<Usuario>(@"exec SP_InsertUsuario @Id_Perfil, @Nombres, @Contraseña, @Email, @Dni", paraneter.ToArray())
            .ToListAsync();
        }

        public async Task<List<Usuario>> Login(LoginDTO usuario)
        {
            var paraneter = new List<SqlParameter>();
            paraneter.Add(new SqlParameter("@Email", usuario.Correo));
            paraneter.Add(new SqlParameter("@Contraseña", usuario.Clave));
            

            return await _dbContext.Usuario
                .FromSqlRaw<Usuario>(@"exec SP_LoggerUsuario @Email, @Contraseña", paraneter.ToArray())
            .ToListAsync();
        }

        public async Task<IEnumerable<ReservaResponse>> GetReservas(int id_usuario)
        {
            var param = new SqlParameter("@id_usuario", id_usuario);

            var ReservaDetails = await Task.Run(() => _dbContext.ReservaResponse
                .FromSqlRaw(@"exec SP_GetReservasPorUsuario @id_usuario", param).ToListAsync());
            return ReservaDetails;
        }


        public async Task<List<HabitacionReservadoResponse>> GetHabitacionesReservados(HabitacionDTO habitacion)
        {
            var paraneter = new List<SqlParameter>();
            paraneter.Add(new SqlParameter("@fecha_inicio", habitacion.fecha_inicio));
            paraneter.Add(new SqlParameter("@fecha_fin", habitacion.fecha_fin));
            paraneter.Add(new SqlParameter("@tipo_habitacion", habitacion.tipo_habitacion));

            return await _dbContext.HabitacionReservadoResponse
                .FromSqlRaw<HabitacionReservadoResponse>(@"exec SP_GetHabitacionReservInFech @fecha_inicio, @fecha_fin, @tipo_habitacion", paraneter.ToArray())
            .ToListAsync();
        }

        public async Task<List<HabitacionResponse>> GetHabitaciones(HabitacionDTO habitacion)
        {
            var paraneter = new List<SqlParameter>();
            paraneter.Add(new SqlParameter("@tipo_habitacion", habitacion.tipo_habitacion));

            return await _dbContext.HabitacionResponse
                .FromSqlRaw<HabitacionResponse>(@"exec SP_GetHabitacionPorTipo @tipo_habitacion", paraneter.ToArray())
            .ToListAsync();
        }


        public async Task<List<HabitacionResponse>> GetPrecioNoche(int id)
        {
            var parm = new List<SqlParameter>();
            parm.Add(new SqlParameter("@id_habitacion", id));

            return await _dbContext.HabitacionResponse
                .FromSqlRaw<HabitacionResponse>(@"exec SP_GetDataHabit @id_habitacion", parm.ToArray())
            .ToListAsync();

        }


        public async Task<List<ReservaResponse>> InsertReserva(InsertReservaDTO InsReserva, decimal precio)
        {
            var paraneter = new List<SqlParameter>();
            paraneter.Add(new SqlParameter("@id_usuario", InsReserva.id_usuario));
            paraneter.Add(new SqlParameter("@id_habitacion", InsReserva.id_habitacion));
            paraneter.Add(new SqlParameter("@fecha_inicio", InsReserva.fecha_inicio));
            paraneter.Add(new SqlParameter("@fecha_fin", InsReserva.fecha_fin));
            paraneter.Add(new SqlParameter("@estado_reserva", "Pendiente"));
            paraneter.Add(new SqlParameter("@monto_total", precio));

            return await _dbContext.ReservaResponse
                .FromSqlRaw<ReservaResponse>(@"exec SP_InsertReserva @id_usuario, @id_habitacion, @fecha_inicio, @fecha_fin, @estado_reserva, @monto_total", paraneter.ToArray())
            .ToListAsync();
        }

        public async Task<List<Reserva>> GetReservasListAdm()
        {
            return await _dbContext.Reserva
                .FromSqlRaw<Reserva>("SP_GetReservasList")
            .ToListAsync();
        }


        public async Task<IEnumerable<ReservaResponse>> ModificarReserva(ModificarReservaDTO reserva)
        {
            var paraneter = new List<SqlParameter>();
            paraneter.Add(new SqlParameter("@id_reserva", reserva.id_reserva));
            paraneter.Add(new SqlParameter("@estado_reserva", reserva.estado_reserva));

            return await _dbContext.ReservaResponse
                .FromSqlRaw<ReservaResponse>(@"exec SP_ModificReserva @id_reserva, @estado_reserva", paraneter.ToArray())
            .ToListAsync();
        }

        public async Task<IEnumerable<DashboardResponse>> GetDataDashboard()
        {
            return await _dbContext.DashboardResponse
                .FromSqlRaw<DashboardResponse>("SP_GetDatosParaDashboard")
            .ToListAsync();
        }

        public async Task<List<DatosGraficResponse>> GetDataGrafic()
        {
            return await _dbContext.DatosGraficResponse
                .FromSqlRaw<DatosGraficResponse>("SP_GetDataGrafico")
            .ToListAsync();
        }
    }
}
