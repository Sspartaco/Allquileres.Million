using Alquileres.Domain;

namespace Alquileres.Common
{
    public class PropertyTraceViewModel
    {
        /// <summary>
        /// Id seguimiento propiedad
        /// </summary>
        public string IdPropertyTrace { get; set; }

        /// <summary>
        /// Fecha Venta
        /// </summary>
        public DateTime DateSale { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Impuesto
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Id Propiedad
        /// </summary>
        public string IdProperty { get; set; }

    }
}
