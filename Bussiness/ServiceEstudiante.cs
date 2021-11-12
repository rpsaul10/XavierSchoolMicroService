using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XavierSchoolMicroService.Models;
using XavierSchoolMicroService.Services;

namespace XavierSchoolMicroService.Bussiness
{
    public class ServiceEstudiante : IServiceEstudiante
    {
        private readonly escuela_xavierContext _context;

        public ServiceEstudiante (escuela_xavierContext context)
        {
            _context = context;
        }

        public bool BajaEstudiante(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Object> GetAll()
        {
            try
            {
                var estuds = from est in _context.Estudiantes
                             join dorm in _context.Dormitorios on est.FkDormitorioEst equals dorm.IdDormitorio
                             join niv in _context.Nivelpoders on est.FkNivelpoderEst equals niv.IdNivel
                             select new
                             {
                                 NombreEstudiante = est.NombreEstudiante,
                                 ApellidoEstudiante = est.ApellidoEstudiante,
                                 FechaNacimiento = est.FechaNacimiento,
                                 NssEstudiante = est.NssEstudiante,
                                 Activo = est.ActivoOInactivo,
                                 Dormitorio = $"Departamento: {dorm.NumeroDpto} Piso: {dorm.Piso}",
                                 Nivel = niv.NombreNivel
                             };
                return estuds;
            } catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }

        public Estudiante GetEstudiante(string id)
        {
            throw new NotImplementedException();
        }

        public bool SaveEstudiante(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEstudiante(string id, Estudiante estudiante)
        {
            throw new NotImplementedException();
        }
    }
}
