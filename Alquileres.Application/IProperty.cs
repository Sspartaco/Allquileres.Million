using Alquileres.Common;

namespace Alquileres.Application
{
    public interface IProperty
    {
        /// <summary>
        /// Metodo para adicionar una propiedad
        /// </summary>
        /// <param name="propertyToAdd">Estructura de toda la propiedad</param>
        /// <returns>Retorna un string delimitado por ; el cual en la posición 0 contiene el id agregado y en la posicion 1 contiene el mensaje de respuesta.</returns>
        public string AddProperty(PropertyViewModel propertyToAdd);

        /// <summary>
        /// Metodo para adicionar una propiedad full, esto se entiende por adición de su correspondienbte imagen y su seguimiento.
        /// </summary>
        /// <param name="fullProperty">Estructura total donde se encuentra la propiedad, imagen de propiead y seguimiento de propiedad</param>
        /// <returns>Retorna un string con 4 posiciones en la posición 0 se encuentra el id de la propiedad, posición 1 id de propiedad imagen, posición 2 id de seguimiento porpiedad y posición 3 mensaje de retorno.</returns>
        public string AddFullProperty(FullPropertyViewModel fullProperty);
    }
}
