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

        /// <summary>
        /// Metodo para obtener solo la estructura basica de una propiedad
        /// </summary>
        /// <returns>Retorna un array de tipo PropertyViewModel con la estructura basica de una propiedad</returns>
        public PropertyViewModel[] GetBasicProperty();

        /// <summary>
        /// Metodo para actualizar el seguimiento y la imagen de una propiedad en caso de que exista alguna información de no ser así se procede a agregar un registro.
        /// </summary>
        /// <param name="fullProperty">Cuerpo correspondiente para hacer la correspondiente actualización o adición de registro.</param>
        /// <returns>Retorna un string indicando el resultado de la ejecución</returns>
        public string UpdateProperty(FullPropertyViewModel fullProperty);

        /// <summary>
        /// Metodo para obtener una propiedad con toda su estructura
        /// </summary>
        /// <param name="idPropeerty">Id correspondiente de la propiedad que se desea filtrar</param>
        /// <returns>Retorna una entidad de tipo FullPropertyViewModel</returns>
        public FullPropertyViewModel GetFullProperty(string idProperty);
    }
}
