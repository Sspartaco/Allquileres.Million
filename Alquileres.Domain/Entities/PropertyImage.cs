using System.ComponentModel.DataAnnotations;

namespace Alquileres.Domain
{
    /// <summary>
    /// Imagenes de la propiedad
    /// </summary>
    public class PropertyImage
    {
        /// <summary>
        /// Id propiedad imagen
        /// </summary>
        [Key]
        public string IdPropertyImage { get; set; }

        /// <summary>
        /// Id propiedad (FK)
        /// </summary>
        public string IdProperty { get; set; }

        /// <summary>
        /// Archivo
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// ¿Habilitado?
        /// </summary>
        public bool Enable { get; set; }
    }
}
