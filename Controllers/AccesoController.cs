using Azure;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Hoteleria.Models;
using Proyecto_Hoteleria.Repositories;
using Proyecto_Hoteleria.Models.DTOs;
using Proyecto_Hoteleria.Custom;
using Proyecto_Hoteleria.Models.RESPONSES;
using System.Drawing;
using System.Collections.Generic;

namespace Proyecto_Hoteleria.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        private readonly Utilidades UTILS;
        public AccesoController(IUsuarioService usuarioService, Utilidades utilidades)
        {
            this.usuarioService = usuarioService;
            this.UTILS = utilidades;
        }

        [HttpGet("GET_LIST_USER")]
        public async Task<IActionResult> GetUsuariosListAsync()
        {
            try {
            
                var response = await usuarioService.GetUsuariosListAsync();
                if (response == null) return null;
                return Ok(new
                {
                    detail = response
                });
            }
            catch { throw; }
        }

        [HttpGet("GET_USER_BY_ID")]
        public async Task<IActionResult> GetUsuarioByIdAsync(int ID)
        {
            try
            {
                var response = await usuarioService.GetUsuarioByIdAsync(ID);
                if (response == null) return null;
                return Ok(new
                {
                    detail = response
                });
            }
            catch { throw; }
        }

        [HttpPost("REGISTER")]
        public async Task<IActionResult> InsertProductAsync(UsuarioDTO USUARIO)
        {
            if (USUARIO == null) return BadRequest();
            try
            {
                var RESPONSE = await usuarioService.Register(USUARIO);

                string MESSAGE = "";
                if (RESPONSE.Count() > 0) MESSAGE = "SUCCESFULL";
                return Ok(new
                {
                    isSuccess = true,
                    detail = RESPONSE,
                    message = MESSAGE,
                    token = UTILS.generarJWT(RESPONSE[0])
                });
            }
            catch
            {
                return Ok(new
                {
                    isSuccess = false,
                    message = "Ya existe el usuario."
                });
            }
        }

        [HttpPost("LOGIN")]
        public async Task<IActionResult> Login(LoginDTO USUARIO)
        {
            if (USUARIO == null) return BadRequest();
            try
            {
                var RESPONSE = await usuarioService.Login(USUARIO);

                string wMESSAGE = "";
                if (RESPONSE.Count() > 0) wMESSAGE = "SUCCESFULL";

                return Ok(new
                {
                    SUCCESS = true,
                    DETAIL = RESPONSE,
                    MESSAGE = wMESSAGE,
                    TOKEN = UTILS.generarJWT(RESPONSE[0])

                }); 
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    SUCCESS = false,
                    TOKEN = "",
                    MESSAGE = ex.Message

                });
            }
        }

        [HttpGet("VALIDATION_TOKEN")]
        public IActionResult ValidarToken([FromQuery]String TOKEN)
        {

            bool RESPONSE = UTILS.validarToken(TOKEN);

            string wMESSAGE = "";
            if (RESPONSE) wMESSAGE = "SUCCESFULL";

            return Ok(new
            {
                SUCCESS = RESPONSE,
                MESSAGE = wMESSAGE
            });
        }

        [HttpGet("GET_RESERVAS")]
        public async Task<IActionResult> GetReservas(int ID)
        {
            var RESPONSE = await usuarioService.GetReservas(ID);
            if (RESPONSE == null) return null;

            return Ok(new
            {
                VALUE = RESPONSE
            });
        }

        [HttpPost("GET_HABITACIONES")]
        public async Task<IActionResult> GetHabitaciones(HabitacionDTO HABITACION)
        {
            if (HABITACION == null) return BadRequest();
            try
            {
                var RESPONSE_RESERVAS = await usuarioService.GetHabitacionesReservados(HABITACION);                

                var RESPONSE_HABITACIONES = await usuarioService.GetHabitaciones(HABITACION);

                List<HabitacionResponse> LIST_HABITACIONES = new List<HabitacionResponse>(RESPONSE_HABITACIONES);

                foreach (var VALUE_RESERV in RESPONSE_RESERVAS)
                {
                    foreach (var VALUE_HABIT in RESPONSE_HABITACIONES)
                    {
                        if (VALUE_RESERV.ID == VALUE_HABIT.ID)
                        {
                            LIST_HABITACIONES.Remove(VALUE_HABIT);
                            break;
                        }
                    }
                }
                var RESPONSE = LIST_HABITACIONES.ToArray();

                return Ok(new
                {
                    HABITACIONES = RESPONSE
                });
                
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    SUCCESS = false,
                    MESSAGE = ex.Message
                });
            }
        }

        [HttpPost("INSERT_RESERVA")]
        public async Task<IActionResult> InsertReserva(InsertReservaDTO INS_RESERVA)
        {
            if (INS_RESERVA == null) return BadRequest();
            try
            {
                var RESPONSE_RESERVA = await usuarioService.GetPrecioNoche(INS_RESERVA.ID_HABITACION);

                var DIAS = INS_RESERVA.FECHA_FIN - INS_RESERVA.FECHA_INICIO;


                decimal PRECIO_TOTAL = RESPONSE_RESERVA[0].PRECIO_NOCHE * DIAS.Days;

                if (PRECIO_TOTAL == 0) PRECIO_TOTAL = RESPONSE_RESERVA[0].PRECIO_NOCHE;

                var RESPONSE = await usuarioService.InsertReserva(INS_RESERVA, PRECIO_TOTAL);

                string wMESSAGE = "";
                if (RESPONSE.Count() > 0) wMESSAGE = "SUCCESFULL";

                return Ok(new
                {
                    SUCCESS = true,
                    MESSAGE = wMESSAGE
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    SUCCESS = false,
                    MESSAGE = ex.Message
                });
            }
        }


        [HttpGet("GET_RESERVAS_LIST")]
        public async Task<IActionResult> GetReservasListAdm()
        {
            try
            {
                var RESPONSE = await usuarioService.GetReservasListAdm();
                if (RESPONSE == null) return null;

                return Ok(new
                {
                    value = RESPONSE
                });
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("UPDATE_RESERVA")]
        public async Task<IActionResult> ModificarReserva(ModificarReservaDTO reserva)
        {
            var RESPONSE = await usuarioService.ModificarReserva(reserva);
            if (RESPONSE == null) return null;

            return Ok(new
            {
                SUCCESS = true,
                MESSAGE = "RESERVA MODIFICADA CON EXITO."
            });
        }

        [HttpGet("GET_DATA_DASHBOARD")]
        public async Task<IActionResult> GetDataDashboard()
        {
            try
            {
                var RESPONSE = await usuarioService.GetDataDashboard();
                if (RESPONSE == null) return null;

                return Ok(new
                {
                    VALUE = RESPONSE
                });
            }
            catch { throw; }
        }

        [HttpGet("GET_DATOS_GRAFIC")]
        public async Task<IActionResult> GetDataGrafic()
        {
            var RESPONSE = await usuarioService.GetDataGrafic();
            if (RESPONSE == null) return null;

            return Ok(new
            {
                VALUE = RESPONSE
            });
        }
    }
}
