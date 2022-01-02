using Microsoft.AspNetCore.Mvc;
using Alquileres.Common;
using System;
using Microsoft.AspNetCore.Http;

namespace Alquileres.Api.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        private readonly IOwner _ownerRepository;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="ownerRepository">Repositorio de tipo Owner</param>
        public OwnerController(IOwner ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        /// <summary>
        /// Metodo para agregar un dueño
        /// </summary>
        /// <param name="owner">Cuerpo correspondiente para adicionar una persona</param>
        /// <returns>Retorna un string indicando si la operación fue exitosa o no.</returns>
        /// <response code="200">Se adiciona correctamente la persona a la base de datos</response>
        /// <response code="400">Alguna validación ha fallado, en esta se devuelve el detalle de la validación que fallo.</response>
        /// <response code="404">Alguna operación fallo, se devuelve su correspondiente mensaje de excepción.</response>
        [HttpPost("AddOwner")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<string> AddOwner([FromBody]OwnerViewModel owner)
        {
            try
            {
                string strMessageResult = null;
                strMessageResult = _ownerRepository.AddOwner(owner);

                if (strMessageResult.Split(';')[1] == "1")
                    return Ok(strMessageResult.Split(';')[2]);
                else
                    return BadRequest(strMessageResult.Split(';')[2]);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Metodo para obtener todos los dueños
        /// </summary>
        /// <returns>Retorna un arreglo en donde se encuentran todas las personas de tipo deuño</returns>
        /// <response code="200">Retorna un arreglo de todos los Owner</response>
        /// <response code="404">Alguna operación fallo, se devuelve su correspondiente mensaje de excepción.</response>
        [HttpGet("GetOwners")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<OwnerViewModel[]> GetOwners()
        {
            try
            {
                return Ok(_ownerRepository.GetOwners());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }
    }
}
