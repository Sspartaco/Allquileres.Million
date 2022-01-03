using Alquileres.Application;
using Alquileres.Common;
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
        /// Metodo para agregar una propiedad
        /// </summary>
        /// <param name="property">Cuerpo correspondiente para adicionar una propiedad</param>
        /// <returns>Retorna un string indicando si la operación fue exitosa o no.</returns>
        /// <response code="200">Se adiciona correctamente la propiedad a la base de datos</response>
        /// <response code="400">Alguna validación ha fallado, en esta se devuelve el detalle de la validación que fallo.</response>
        /// <response code="404">Alguna operación fallo, se devuelve su correspondiente mensaje de excepción.</response>
        [HttpPost("AddProperty")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<string> AddProperty([FromBody] PropertyViewModel property)
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

        /// <summary>
        /// Metodo para agregar una propiedad
        /// </summary>
        /// <param name="fullProperty">Cuerpo correspondiente para adicionar una propiedad</param>
        /// <returns>Retorna un string indicando si la operación fue exitosa o no.</returns>
        /// <response code="200">Se adiciona correctamente la propiedad a la base de datos</response>
        /// <response code="400">Alguna validación ha fallado, en esta se devuelve el detalle de la validación que fallo.</response>
        /// <response code="404">Alguna operación fallo, se devuelve su correspondiente mensaje de excepción.</response>
        [HttpPost("AddFullProperty")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<string> AddFullProperty([FromBody] FullPropertyViewModel fullProperty)
        {
            try
            {
                string strMessageResult = null;
                strMessageResult = _propertyRepository.AddFullProperty(fullProperty);

                if (strMessageResult.Split(';')[2] == "1")
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
        /// Metodo para obtener la estructura basica de una propiedad
        /// </summary>
        /// <returns>Retorna un arreglo con toda su estructura correspondiente.</returns>
        /// <response code="200">Retorna el arreglo correspondiente a la propiedad</response>
        /// <response code="404">Alguna operación fallo, se devuelve su correspondiente mensaje de excepción.</response>
        [HttpGet("GetBasicProperty")]
        [ProducesResponseType(typeof(PropertyViewModel[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<PropertyViewModel[]> GetBasicProperty()
        {
            try
            {
                return Ok(_propertyRepository.GetBasicProperty());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Metodo para agregar una propiedad
        /// </summary>
        /// <param name="fullProperty">Cuerpo correspondiente para adicionar una propiedad</param>
        /// <returns>Retorna un string indicando si la operación fue exitosa o no.</returns>
        /// <response code="200">Se adiciona correctamente la propiedad a la base de datos</response>
        /// <response code="400">Alguna validación ha fallado, en esta se devuelve el detalle de la validación que fallo.</response>
        /// <response code="404">Alguna operación fallo, se devuelve su correspondiente mensaje de excepción.</response>
        [HttpPost("UpdateProperty")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<string> UpdateProperty([FromBody] FullPropertyViewModel fullProperty)
        {
            try
            {
                string strMessageResult = null;
                strMessageResult = _propertyRepository.UpdateProperty(fullProperty);

                if (strMessageResult.Split(';')[0] == "1")
                    return Ok(strMessageResult.Split(';')[1]);
                else
                    return BadRequest(strMessageResult.Split(';')[1]);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Metodo para obtener toda la estructura de una propiedad
        /// </summary>
        /// <param name="idProperty">Id correspondiente de la propiedad que se desea filtrar</param>
        /// <returns>Retorna una entidad con toda su estructura correspondiente.</returns>
        /// <response code="200">Retorna la entidad correspondiente a la propiedad</response>
        /// <response code="404">Alguna operación fallo, se devuelve su correspondiente mensaje de excepción.</response>
        [HttpGet("GetFullPropertyById")]
        [ProducesResponseType(typeof(FullPropertyViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public ActionResult<FullPropertyViewModel> GetFullPropertyById(string idProperty)
        {
            try
            {
                return Ok(_propertyRepository.GetFullProperty(idProperty));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }
    }
}
