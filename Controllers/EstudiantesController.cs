using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XavierSchoolMicroService.Services;

namespace XavierSchoolMicroService.Controllers
{
    public class EstudiantesController : ControllerBase
    {
        private readonly IServiceEstudiante _service;

        public EstudiantesController(IServiceEstudiante service)
        {
            _service = service;
        }

        [HttpGet("api/estudiantes/all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllEstudiantes()
        {
            try
            {
                var estudiantes = _service.GetAll();
                return Ok(estudiantes);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
