using Alquileres.Common;
using Alquileres.Domain;
using Alquileres.Infrastructuree.EntityFrameworkDatabaseContext;
using AutoMapper;
using System;
using System.Linq;

namespace Alquileres.Logic
{
    public class OwnerRepository : IOwner
    {
        private readonly AlquileresDBContext _context;
        private readonly IMapper _mapper;

        public OwnerRepository(AlquileresDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo para agregar un dueño.
        /// </summary>
        /// <param name="ownerToAdd">Se solicita una entidad de Tipo OwnerProfile, esta recibe todos los parametros a excepción del idOwner</param>
        /// <returns>Retorna un string delimitado con el caracter ';', en la primer posición se encuentra el id correspondiente al Dueño, y en la segunda posición se encuentra el mensaje de validación</returns>
        public string AddOwner(OwnerViewModel ownerToAdd)
        {
            try
            {
                string strMessageToReturn;
                Owner owner = _mapper.Map<Owner>(ownerToAdd);
                strMessageToReturn = Guid.NewGuid().ToString() + ";";

                var ownerExists = _context.Owners.ToList();
                var ownerExistsValidation = ownerExists.Find(x => x.Name.ToLower().Trim().Equals(ownerToAdd.Name.ToLower().Trim()) && x.Address.ToLower().Trim().Equals(ownerToAdd.Address.ToLower().Trim()));

                if (ownerExistsValidation != null)
                    strMessageToReturn += "0;" + string.Concat("El registro que esta intentando adicionar con nombre: ", ownerToAdd.Name, " y dirección: ", ownerToAdd.Address, " ya existe en nuestra base de datos.");
                else
                {
                    owner.IdOwner = strMessageToReturn.Split(';')[0];
                    _context.Owners.Add(owner);
                    _context.SaveChanges();

                    strMessageToReturn += "1;" + "Se ha adicionado correctamente el registro.";
                }

                return strMessageToReturn;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener todas las personas
        /// </summary>
        /// <returns>Retorna un arreglo de tipo OwnerViewModel</returns>
        public OwnerViewModel[] GetOwners()
        {
            try
            {
                var Owners = _context.Owners.ToArray();

                return _mapper.Map<OwnerViewModel[]>(Owners);
            }
            catch
            {
                throw;
            }
        }
    }
}
