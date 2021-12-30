namespace Alquileres.Common
{
    /// <summary>
    /// Estructura para adicionar una propiedad full
    /// </summary>
    public class FullPropertyViewModel
    {
        /// <summary>
        /// Estructura correspondiente a la propiedad
        /// </summary>
        public PropertyViewModel Property { get; set; }

        /// <summary>
        /// Estructura correspondiente a la imagen de la propiedad
        /// </summary>
        public PropertyImageViewModel PropertyImage { get; set; }

        /// <summary>
        /// Estructura correspondiente al seguimiento de la propiedad
        /// </summary>
        public PropertyTraceViewModel PropertyTrace { get; set; }
    }
}
