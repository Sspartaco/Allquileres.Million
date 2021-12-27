using Alquileres.Domain;
using Microsoft.EntityFrameworkCore;

namespace Alquileres.Infrastructuree.EntityFrameworkDatabaseContext
{
    public class AlquileresDBContext : DbContext
    {
        /// <summary>
        /// Mapeo de tabla dueño
        /// </summary>
        public DbSet<Owner> Owners { get; set; }

        public AlquileresDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
