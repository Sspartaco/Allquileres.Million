using Alquileres.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alquileres.Application
{
    public interface IOwner
    {
        public List<Owner> GetOwners();
    }
}
