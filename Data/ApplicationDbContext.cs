using Microsoft.EntityFrameworkCore;
using inmobiliariaPrueva1.Models;

namespace inmobiliariaPrueva1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Inquilino>Inquilinos{get; set;}

        public DbSet<Propietario>Propietarios{get; set;}
        
            
        
    }
}