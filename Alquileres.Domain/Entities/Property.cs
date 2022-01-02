using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alquileres.Domain
{

    /// <summary>
    /// Propiedades
    /// </summary>
    public class Property
    {

        /// <summary>
        /// Id propiedad
        /// </summary>
        [Key]
        [JsonIgnore]
        public string IdProperty
        { get; set; }

        /// <summary>
        /// Nombre propiedad
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Dirección propiedad
        /// </summary>
        public string Address
        { get; set; }

        /// <summary>
        /// Precio propiedad
        /// </summary>
        public string Price
        { get; set; }

        /// <summary>
        /// Codigo interno propiedad
        /// </summary>
        public string CodeInternal
        { get; set; }

        /// <summary>
        /// Año de la propiedad
        /// </summary>
        public int Year
        { get; set; }

        /// <summary>
        /// Id del dueño
        /// </summary>
        [ForeignKey("Owner")]
        public string IdOwner
        { get; set; }

        [JsonIgnore]
        public virtual Owner Owners { get; set; }
    }
}
