using Alquileres.Application;
using Alquileres.Domain;
using Alquileres.Infrastructuree.EntityFrameworkDatabaseContext;
using Alquileres.Common;
using AutoMapper;
using System;
using System.Linq;

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
                property.IdProperty = strMessageToReturn.Split(';')[0];

                _context.Property.Add(property);
                _context.SaveChanges();
                strMessageToReturn += "1;Se ha adicionado correctamente la propiedad";

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
                strMessageToReturn += "1;Se ha adicionado correctamente la propiedad.";

                return strMessageToReturn;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener solo la estructura basica de una propiedad
        /// </summary>
        /// <returns>Retorna un array de tipo PropertyViewModel con la estructura basica de una propiedad</returns>
        public PropertyViewModel[] GetBasicProperty()
        {
            try
            {
                var result = _context.Property.ToArray();
                return _mapper.Map<PropertyViewModel[]>(result);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para actualizar el seguimiento y la imagen de una propiedad en caso de que exista alguna información de no ser así se procede a agregar un registro.
        /// </summary>
        /// <param name="fullProperty">Cuerpo correspondiente para hacer la correspondiente actualización o adición de registro.</param>
        /// <returns>Retorna un string indicando el resultado de la ejecución</returns>
        public string UpdateProperty(FullPropertyViewModel fullProperty)
        {
            try
            {
                Property property = _mapper.Map<Property>(fullProperty.Property);
                PropertyImage propertyImage = _mapper.Map<PropertyImage>(fullProperty.PropertyImage);
                PropertyTrace propertyTrace = _mapper.Map<PropertyTrace>(fullProperty.PropertyTrace);

                string strMessageToReturn = null;
                strMessageToReturn = string.Concat(property.IdProperty, ";");
                if (property.IdProperty != null)
                {
                    propertyImage.IdProperty = property.IdProperty;
                    propertyTrace.IdProperty = property.IdProperty;

                    propertyImage.IdPropertyImage = (fullProperty.PropertyImage.IdPropertyImage == "" ? null : fullProperty.PropertyImage.IdPropertyImage) == null ? Guid.NewGuid().ToString() : fullProperty.PropertyImage.IdPropertyImage;
                    propertyTrace.IdPropertyTrace = (fullProperty.PropertyTrace.IdPropertyTrace == "" ? null : fullProperty.PropertyTrace.IdPropertyTrace) == null ? Guid.NewGuid().ToString() : fullProperty.PropertyTrace.IdPropertyTrace;

                    var existingPropertyImage = _context.PropertyImage;
                    if (existingPropertyImage.Where(x => x.IdPropertyImage == propertyImage.IdPropertyImage).Count() > 0)
                        _context.PropertyImage.Update(propertyImage);
                    else
                        _context.PropertyImage.Add(propertyImage);

                    var existingPropertyTrace = _context.PropertyTrace;
                    if (existingPropertyTrace.Where(x => x.IdPropertyTrace == propertyTrace.IdPropertyTrace).Count() > 0)
                        _context.PropertyTrace.Update(propertyTrace);
                    else
                        _context.PropertyTrace.Add(propertyTrace);

                    _context.SaveChanges();

                    strMessageToReturn += string.Concat("1;", "Se ha actualizado correctamente la información de la propiedad.");
                }
                else
                    strMessageToReturn += string.Concat("2;", "Información incompleta por favor vuelva a intentar.");

                return strMessageToReturn;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener una propiedad con toda su estructura
        /// </summary>
        /// <param name="idProperty">Id correspondiente de la propiedad que se desea filtrar</param>
        /// <returns>Retorna una entidad de tipo FullPropertyViewModel</returns>
        public FullPropertyViewModel GetFullProperty(string idProperty)
        {
            try
            {
                var property = _context.Property.Where(x => x.IdProperty == idProperty).FirstOrDefault();
                PropertyImageViewModel propertyImageViewModel = new PropertyImageViewModel();
                PropertyTraceViewModel propertyTraceViewModel = new PropertyTraceViewModel();
                PropertyViewModel propertyViewModel = new PropertyViewModel();
                if (property != null)
                {
                    propertyViewModel = _mapper.Map<PropertyViewModel>(property);
                    var propertyImage = _context.PropertyImage.Where(x => x.IdProperty == property.IdProperty).FirstOrDefault();
                    if (propertyImage != null)
                        propertyImageViewModel = _mapper.Map<PropertyImageViewModel>(propertyImage);
                    else
                        propertyImageViewModel = new PropertyImageViewModel();

                    var propertyTrace = _context.PropertyTrace.Where(x => x.IdProperty == property.IdProperty).FirstOrDefault();
                    if (propertyTrace != null)
                        propertyTraceViewModel = _mapper.Map<PropertyTraceViewModel>(propertyTrace);
                    else
                        propertyTraceViewModel = new PropertyTraceViewModel();
                }

                FullPropertyViewModel fullPropertyViewModel = new FullPropertyViewModel();
                fullPropertyViewModel.Property = propertyViewModel;
                fullPropertyViewModel.PropertyImage = propertyImageViewModel;
                fullPropertyViewModel.PropertyTrace = propertyTraceViewModel;

                return fullPropertyViewModel;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener solo la estructura basica de una propiedad filtrada por su id
        /// </summary>
        /// <param name="idProperty">Id correspondiente de la propiedad que se desea filtrar</param>
        /// <returns>Retorna una entidad PropertyViewModel con la estructura basica de una propiedad</returns>
        public PropertyViewModel GetBasicPropertyById(string idProperty)
        {
            try
            {
                var property = _context.Property.Where(x => x.IdProperty == idProperty).FirstOrDefault();
                return _mapper.Map<PropertyViewModel>(property);
            }
            catch
            {
                throw;
            }
        }
    }
}
