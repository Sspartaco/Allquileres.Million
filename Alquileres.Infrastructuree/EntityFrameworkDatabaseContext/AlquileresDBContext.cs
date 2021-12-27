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

        /// <summary>
        /// Seguimiento propiedad
        /// </summary>
        public DbSet<PropertyTrace> PropertyTrace { get; set; }

        /// <summary>
        /// Propiedades
        /// </summary>
        public DbSet<Property> Property { get; set; }

        /// <summary>
        /// Imagenes propiedades
        /// </summary>
        public DbSet<PropertyImage> PropertyImage { get; set; }

        public AlquileresDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
