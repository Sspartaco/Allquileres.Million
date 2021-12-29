namespace Alquileres.Application
{
    public interface IOwner
    {
        /// <summary>
        /// Metodo para agregar un dueño.
        /// </summary>
        /// <param name="ownerToAdd">Se solicita una entidad de Tipo OwnerProfile, esta recibe todos los parametros a excepción del idOwner</param>
        /// <returns>Retorna un string delimitado con el caracter ';', en la primer posición se encuentra el id correspondiente al Dueño, y en la segunda posición se encuentra el mensaje de validación</returns>
        public string AddOwner(OwnerViewModel ownerToAdd);

        /// <summary>
        /// Metodo para obtener todas las personas
        /// </summary>
        /// <returns>Retorna un arreglo de tipo OwnerViewModel</returns>
        public OwnerViewModel[] GetOwners();
    }
}
