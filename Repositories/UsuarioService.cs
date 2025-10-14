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
        public UsuarioService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Usuario>> GetUsuariosListAsync()
        {
            return await _dbContext.Usuario
                .FromSqlRaw("SP_GetUsuarioList")
            .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioByIdAsync(int USUARIO_ID)
        {
            var PARAMETER = new SqlParameter("@USUARIO_ID", USUARIO_ID);

            var USER_DETAILS = await Task.Run(() => _dbContext.Usuario
                .FromSqlRaw(@"EXEC SP_GetUsuarioByID @USUARIO_ID", PARAMETER).ToListAsync());
            return USER_DETAILS;
        }

        public async Task<List<Usuario>> Register(UsuarioDTO USUARIO)
        {
            var PARAMETERS = new List<SqlParameter>
            {
                new SqlParameter("@ID_PERFIL", USUARIO.ID_PERFIL),
                new SqlParameter("@NOMBRES", USUARIO.NOMBRES),
                new SqlParameter("@APELLIDOS", USUARIO.APELLIDOS),
                new SqlParameter("@TELEFONO", USUARIO.TELEFONO),
                new SqlParameter("@TIPO_DOCUMENTO_ID", USUARIO.TIPO_DOCUMENTO_ID),
                new SqlParameter("@DOCUMENTO", USUARIO.DOCUMENTO),
                new SqlParameter("@EMAIL", USUARIO.EMAIL),
                new SqlParameter("@PASSWORDS", USUARIO.PASSWORD)
            };

            return await _dbContext.Usuario
                .FromSqlRaw(@"EXEC SP_InsertUsuario 
                      @ID_PERFIL, 
                      @NOMBRES, 
                      @APELLIDOS, 
                      @TELEFONO, 
                      @TIPO_DOCUMENTO_ID, 
                      @DOCUMENTO, 
                      @EMAIL, 
                      @PASSWORDS",
                              PARAMETERS.ToArray())
                .ToListAsync();
        }


        public async Task<List<Usuario>> Login(LoginDTO USUARIO)
        {
            var PARAMETERS = new List<SqlParameter>
            {
                new SqlParameter("@EMAIL_DOCUMENTO", USUARIO.EMAIL_DOCUMENTO),
                new SqlParameter("@PASSWORDS", USUARIO.PASSWORD)
            };
            
            return await _dbContext.Usuario
                .FromSqlRaw(@"EXEC SP_LoggerUsuario @EMAIL_DOCUMENTO, @PASSWORDS", PARAMETERS.ToArray())
            .ToListAsync();
        }

        public async Task<IEnumerable<ReservaResponse>> GetReservas(int ID_USER)
        {
            var PARAMETER = new SqlParameter("@ID_USUARIO", ID_USER);

            var ReservaDetails = await Task.Run(() => _dbContext.ReservaResponse
                .FromSqlRaw(@"EXEC SP_GetReservasPorUsuario @ID_USUARIO", PARAMETER).ToListAsync());
            return ReservaDetails;
        }


        public async Task<List<HabitacionReservadoResponse>> GetHabitacionesReservados(HabitacionDTO HABITACION)
        {
            var PARAMETERS = new List<SqlParameter>
            {
                new SqlParameter("@FECHA_INICIO", HABITACION.FECHA_INICIO),
                new SqlParameter("@FECHA_FIN", HABITACION.FECHA_FIN),
                new SqlParameter("@TIPO_HABITACION_ID", HABITACION.TIPO_HABITACION_ID)
            };

            return await _dbContext.HabitacionReservadoResponse
                .FromSqlRaw(@"EXEC SP_GetHabitacionReservInFech @FECHA_INICIO, @FECHA_FIN, @TIPO_HABITACION_ID", PARAMETERS.ToArray())
            .ToListAsync();
        }

        public async Task<List<HabitacionResponse>> GetHabitaciones(HabitacionDTO habitacion)
        {
            var paraneter = new List<SqlParameter>();
            paraneter.Add(new SqlParameter("@TIPO_HABITACION_ID", habitacion.TIPO_HABITACION_ID));

            return await _dbContext.HabitacionResponse
                .FromSqlRaw(@"EXEC SP_GetHabitacionPorTipo @TIPO_HABITACION_ID", paraneter.ToArray())
            .ToListAsync();
        }


        public async Task<List<HabitacionResponse>> GetPrecioNoche(int ID)
        {
            var PARAMETERS = new List<SqlParameter>
            {
                new SqlParameter("@ID_HABITACION", ID)
            };

            return await _dbContext.HabitacionResponse
                .FromSqlRaw(@"EXEC SP_GetDataHabit @ID_HABITACION", PARAMETERS.ToArray())
            .ToListAsync();

        }


        public async Task<List<ReservaResponse>> InsertReserva(InsertReservaDTO INS_RESERVA, decimal PRECIO)
        {
            var PARAMETERS = new List<SqlParameter>
            {
                new SqlParameter("@ID_USUARIO", INS_RESERVA.ID_USUARIO),
                new SqlParameter("@ID_HABITACION", INS_RESERVA.ID_HABITACION),
                new SqlParameter("@FECHA_INICIO", DateTime.Parse(INS_RESERVA.FECHA_INICIO.ToString()).ToString("yyyy-MM-dd")),
                new SqlParameter("@FECHA_FIN", DateTime.Parse(INS_RESERVA.FECHA_FIN.ToString()).ToString("yyyy-MM-dd")),
                new SqlParameter("@ID_ESTADO_RESERVA", 1),
                new SqlParameter("@MONTO_RESERVA", PRECIO)
            };
            return await _dbContext.ReservaResponse
                .FromSqlRaw(@"EXEC SP_InsertReserva @ID_USUARIO, @ID_HABITACION, @FECHA_INICIO, @FECHA_FIN, @ID_ESTADO_RESERVA, @MONTO_RESERVA", PARAMETERS.ToArray())
            .ToListAsync();
        }

        public async Task<List<Reserva>> GetReservasListAdm()
        {
            return await _dbContext.Reserva
                .FromSqlRaw("SP_GetReservasList")
            .ToListAsync();
        }


        public async Task<IEnumerable<ReservaResponse>> ModificarReserva(ModificarReservaDTO reserva)
        {
            var PARAMETERS = new List<SqlParameter>
            {
                new SqlParameter("@ID_RESERVA", reserva.ID_RESERVA),
                new SqlParameter("@ESTADO_RESERVA_ID", reserva.ESTADO_RESERVA_ID)
            };

            return await _dbContext.ReservaResponse
                .FromSqlRaw(@"EXEC [SP_UpdateReserva] @ID_RESERVA, @ESTADO_RESERVA_ID", PARAMETERS.ToArray())
            .ToListAsync();
        }

        public async Task<IEnumerable<DashboardResponse>> GetDataDashboard()
        {
            return await _dbContext.DashboardResponse
                .FromSqlRaw("SP_GetDatosParaDashboard")
            .ToListAsync();
        }

        public async Task<List<DatosGraficResponse>> GetDataGrafic()
        {
            return await _dbContext.DatosGraficResponse
                .FromSqlRaw("SP_GetDataGrafico")
            .ToListAsync();
        }
    }
}
