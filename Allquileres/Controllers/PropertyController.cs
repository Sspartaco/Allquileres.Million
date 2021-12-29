using Alquileres.Application;
using Alquileres.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Alquileres.Api.Controllers
{
    [Route("api/[controller]")]
    public class PropertyController : Controller
    {
        private readonly IProperty _propertyRepository;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="propertyRepository">Repositorio de tipo property</param>
        public PropertyController(IProperty propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        /// <summary>
        /// Metodo para agregar un dueño
        /// </summary>
        /// <param name="property">Cuerpo correspondiente para adicionar una propiedad</param>
        /// <returns>Retorna un string indicando si la operación fue exitosa o no.</returns>
        /// <response code="200">Se adiciona correctamente la persona a la base de datos</response>
        /// <response code="400">Alguna validación ha fallado, en esta se devuelve el detalle de la validación que fallo.</response>
        /// <response code="404">Alguna operación fallo, se devuelve su correspondiente mensaje de excepción.</response>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<string> AddOwner(PropertyViewModel property)
        {
            try
            {
                string strMessageResult = null;
                strMessageResult = _propertyRepository.AddProperty(property);

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
    }
}
