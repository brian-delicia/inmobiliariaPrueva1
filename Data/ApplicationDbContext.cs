using Microsoft.EntityFrameworkCore;
using inmobiliariaPrueva1.Models;

namespace inmobiliariaPrueva1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Inquilino>Inquilinos {get; set;}

        public DbSet<Propietario>Propietarios {get; set;}

        public DbSet<Inmueble>Inmuebles {get; set; }

        public DbSet<Reserva>Reservas {get; set;}

        public DbSet<Pagos>Pagos {get; set; }
        
        public DbSet<Usuario>Usuarios {get; set; }
        
            
        
    }
}