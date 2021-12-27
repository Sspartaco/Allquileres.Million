using System.Collections.Generic;
using Alquileres.Application;
using Alquileres.Infrastructuree.EntityFrameworkDatabaseContext;
using Alquileres.Domain;
using System.Linq;

namespace Alquileres.Logic
{
    public class OwnerRepository : IOwner
    {
        private readonly AlquileresDBContext _context;

        public OwnerRepository(AlquileresDBContext context)
        {
            _context = context;
        }

        public List<Owner> GetOwners()
        {
            try
            {
                return _context.Owners.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
