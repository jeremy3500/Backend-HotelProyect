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
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        private readonly Utilidades _utilidades;
        public AccesoController(IUsuarioService usuarioService, Utilidades utilidades)
        {
            this.usuarioService = usuarioService;
            this._utilidades = utilidades;
        }

        [HttpGet("getUsuariosList")]
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
            catch
            {
                throw;
            }
        }

        [HttpGet("getUsuarioById")]
        public async Task<IActionResult> GetUsuarioByIdAsync(int Id)
        {
            try
            {
                var response = await usuarioService.GetUsuarioByIdAsync(Id);
                if (response == null) return null;
                return Ok(new
                {
                    detail = response
                });
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> InsertProductAsync(UsuarioDTO usuario)
        {
            if (usuario == null) return BadRequest();
            try
            {
                var response = await usuarioService.Register(usuario);

                string wMessage = "";
                if (response.Count() > 0) wMessage = "succesfull";
                return Ok(new
                {
                    isSuccess = true,
                    detail = response,
                    message = wMessage,
                    token = _utilidades.generarJWT(response[0])
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO usuario)
        {
            if (usuario == null) return BadRequest();
            try
            {
                var response = await usuarioService.Login(usuario);

                string wMessage = "";
                if (response.Count() > 0) wMessage = "succesfull";

                return Ok(new
                {
                    isSuccess = true,
                    detail = response,
                    message = wMessage,
                    token = _utilidades.generarJWT(response[0])

                }); 
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    isSuccess = false,
                    token = "",
                    message = ex.Message

                });
                //return StatusCode(StatusCodes.Status500InternalServerError, new
                //{
                //    isSuccess = false,
                //    token = "",
                //    message = ex.Message
                //});
            }
        }

        [HttpGet("ValidarToken")]
        public IActionResult ValidarToken([FromQuery]String token)
        {

            bool respuesta = _utilidades.validarToken(token);

            string wMessage = "";
            if (respuesta) wMessage = "succesfull";

            return Ok(new
            {
                isSuccess = respuesta,
                message = wMessage
            });
        }

        [HttpGet("getReservas")]
        public async Task<IActionResult> GetReservas(int Id)
        {
            var response = await usuarioService.GetReservas(Id);
            if (response == null) return null;

            return Ok(new
            {
                value = response
            });
        }

        [HttpPost("GetHabitaciones")]
        public async Task<IActionResult> GetHabitaciones(HabitacionDTO habitacion)
        {
            if (habitacion == null) return BadRequest();
            try
            {
                var response_reservas = await usuarioService.GetHabitacionesReservados(habitacion);                

                var response_habitaciones = await usuarioService.GetHabitaciones(habitacion);

                List<HabitacionResponse> list_habitaciones = new List<HabitacionResponse>(response_habitaciones);

                foreach (var value_reserv in response_reservas)
                {
                    foreach (var value_habit in response_habitaciones)
                    {
                        if (value_reserv.id == value_habit.id)
                        {
                            list_habitaciones.Remove(value_habit);
                            break;
                        }
                    }
                }
                var response = list_habitaciones.ToArray();

                string wMessage = "";
                if (response.Count() > 0) wMessage = "succesfull";

                return Ok(new
                {
                    habitaciones = response
                });
                
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    isSuccess = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost("InsertReserva")]
        public async Task<IActionResult> InsertReserva(InsertReservaDTO InsReserva)
        {
            if (InsReserva == null) return BadRequest();
            try
            {
                var response_reservas = await usuarioService.GetPrecioNoche(InsReserva.id_habitacion);

                var dias = InsReserva.fecha_fin - InsReserva.fecha_inicio;


                decimal wprecioTotal = response_reservas[0].precio_noche * dias.Days;

                if (wprecioTotal == 0) wprecioTotal = response_reservas[0].precio_noche;

                var response = await usuarioService.InsertReserva(InsReserva, wprecioTotal);

                string wMessage = "";
                if (response.Count() > 0) wMessage = "succesfull";

                return Ok(new
                {
                    isSuccess = true,
                    message = wMessage
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    isSuccess = false,
                    message = ex.Message
                });
            }
        }


        [HttpGet("getReservasList")]
        public async Task<IActionResult> GetReservasListAdm()
        {
            try
            {
                var response = await usuarioService.GetReservasListAdm();
                if (response == null) return null;

                return Ok(new
                {
                    value = response
                });
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("modificarReserva")]
        public async Task<IActionResult> ModificarReserva(ModificarReservaDTO reserva)
        {
            var response = await usuarioService.ModificarReserva(reserva);
            if (response == null) return null;

            return Ok(new
            {
                isSuccess = true,
                message = "Modificado con Exito."
            });
        }

        [HttpGet("getDataDashboard")]
        public async Task<IActionResult> GetDataDashboard()
        {
            try
            {
                var response = await usuarioService.GetDataDashboard();
                if (response == null) return null;

                return Ok(new
                {
                    value = response
                });
            }
            catch { throw; }
        }

        [HttpGet("getDatosGrafic")]
        public async Task<IActionResult> GetDataGrafic()
        {
            var response = await usuarioService.GetDataGrafic();
            if (response == null) return null;

            return Ok(new
            {
                value = response
            });
        }
    }
}
