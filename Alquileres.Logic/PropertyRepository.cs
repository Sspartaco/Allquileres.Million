using Alquileres.Application;
using Alquileres.Domain;
using Alquileres.Infrastructuree.EntityFrameworkDatabaseContext;
using Alquileres.Mapping;
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
    }
}
