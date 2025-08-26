using Microsoft.EntityFrameworkCore;
using Proyecto_Hoteleria.Models.DTOs;
using Proyecto_Hoteleria.Models.RESPONSES;

namespace Proyecto_Hoteleria.Models
{
    public class DbContextClass: DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public virtual  DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<ReservaResponse> ReservaResponse { get; set; }
        public virtual DbSet<HabitacionResponse> HabitacionResponse { get; set; }
        public virtual DbSet<HabitacionReservadoResponse> HabitacionReservadoResponse { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<DashboardResponse> DashboardResponse { get; set; }
        public virtual DbSet<DatosGraficResponse> DatosGraficResponse { get; set; }
    }
}
