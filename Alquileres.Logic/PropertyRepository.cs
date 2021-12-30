using Alquileres.Application;
using Alquileres.Domain;
using Alquileres.Infrastructuree.EntityFrameworkDatabaseContext;
using Alquileres.Common;
using AutoMapper;
using System;

namespace Alquileres.Logic
{
    public class PropertyRepository : IProperty
    {
        private readonly AlquileresDBContext _context;
        private readonly IMapper _mapper;

        public PropertyRepository(AlquileresDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para adicionar una propiedad
        /// </summary>
        /// <param name="propertyToAdd">Estructura de toda la propiedad</param>
        /// <returns>Retorna un string delimitado por ; el cual en la posición 0 contiene el id agregado y en la posicion 1 contiene el mensaje de respuesta.</returns>
        public string AddProperty(PropertyViewModel propertyToAdd)
        {
            try
            {
                string strMessageToReturn = null;
                Property property = _mapper.Map<Property>(propertyToAdd);

                strMessageToReturn = string.Concat(Guid.NewGuid().ToString(), ";");
                property.IdOwner = strMessageToReturn.Split(';')[0];

                _context.Property.Add(property);
                _context.SaveChanges();
                strMessageToReturn += "Se ha adicionado correctamente la propiedad";

                return strMessageToReturn;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para adicionar una propiedad full, esto se entiende por adición de su correspondienbte imagen y su seguimiento.
        /// </summary>
        /// <param name="fullProperty">Estructura total donde se encuentra la propiedad, imagen de propiead y seguimiento de propiedad</param>
        /// <returns>Retorna un string con 4 posiciones en la posición 0 se encuentra el id de la propiedad, posición 1 id de propiedad imagen, posición 2 id de seguimiento porpiedad y posición 3 mensaje de retorno.</returns>
        public string AddFullProperty(FullPropertyViewModel fullProperty)
        {
            try
            {
                string strMessageToReturn = null;
                Property property = _mapper.Map<Property>(fullProperty.Property);
                PropertyImage propertyImage = _mapper.Map<PropertyImage>(fullProperty.PropertyImage);
                PropertyTrace propertyTrace = _mapper.Map<PropertyTrace>(fullProperty.PropertyTrace);

                strMessageToReturn = string.Concat(Guid.NewGuid().ToString(), ";", Guid.NewGuid().ToString(), ";", Guid.NewGuid().ToString());

                property.IdProperty = strMessageToReturn.Split(';')[0];
                propertyImage.IdPropertyImage = strMessageToReturn.Split(';')[1];
                propertyImage.IdProperty = property.IdProperty;
                propertyTrace.IdPropertyTrace = strMessageToReturn.Split(';')[2];
                propertyTrace.IdProperty = property.IdProperty;

                _context.Property.Add(property);
                _context.PropertyImage.Add(propertyImage);
                _context.PropertyTrace.Add(propertyTrace);
                _context.SaveChanges();
                strMessageToReturn += "Se ha adicionado correctamente la propiedad.";

                return strMessageToReturn;
            }
            catch
            {
                throw;
            }
        }
    }
}
