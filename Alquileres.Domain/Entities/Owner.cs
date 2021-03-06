using System;
using System.ComponentModel.DataAnnotations;

namespace Alquileres.Domain
{
    /// <summary>
    /// Taba correspondiente al dueño
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Identificador principal de la tabla dueño
        /// </summary>
        [Key]
        public string IdOwner
        { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Dirección
        /// </summary>
        public string Address
        { get; set; }

        /// <summary>
        /// Ruta de la foto
        /// </summary>
        public string Photo
        { get; set; }

        /// <summary>
        /// Cumpleaños de la persona
        /// </summary>
        public DateTimeOffset BirthDay
        { get; set; }
    }
}
