using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XavierSchoolMicroService.Models;
using XavierSchoolMicroService.Services;


namespace XavierSchoolMicroService.Controllers
{
    public class LeccionGrupoController : ControllerBase
    {
        private readonly IServiceLecPublicas _service;

        public LeccionGrupoController(IServiceLecPublicas service)
        {
            _service = service;
        }

        [HttpGet("api/lecGrupo/all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllLeccionesGrupo()
        {
            try
            {
                var lecs = _service.GetAll();
                return Ok (lecs);    
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet ("api/lecGrupo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Leccionpublica))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetLeccionGrupo(string id)
        {
            try
            {
                var lecc = _service.GetLecPublica(id);
                if (lecc == null)
                    return BadRequest("Nel pa");
                return Ok (lecc);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}