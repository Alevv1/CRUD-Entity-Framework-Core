using Microsoft.EntityFrameworkCore;
using TestProyecto.Models;

namespace TestProyecto.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        //Agregar los modelos acá (Cada modelo corresponde a una tabla en la Base de Datos
        
        public DbSet<Contacto> Contacto { get; set; }







    }
}
