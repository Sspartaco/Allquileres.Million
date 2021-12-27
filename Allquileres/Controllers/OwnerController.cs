using Microsoft.AspNetCore.Mvc;
using Alquileres.Application;
using System.Collections.Generic;
using Alquileres.Domain;

namespace Alquileres.Api.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private readonly IOwner _OwnerRepository;

        public OwnerController(IOwner ownerRepository)
        {
            _OwnerRepository = ownerRepository;
        }

    }
}
