using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [ForeignKey("Property")]
        public string IdProperty { get; set; }

        /// <summary>
        /// Archivo
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// ¿Habilitado?
        /// </summary>
        public bool Enable { get; set; }

        [JsonIgnore]
        public virtual Property Properties { get; set; }
    }
}
