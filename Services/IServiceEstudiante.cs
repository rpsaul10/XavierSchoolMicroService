using System;
using System.Collections.Generic;
using System.Linq;
using XavierSchoolMicroService.Models;
using System.Threading.Tasks;

namespace XavierSchoolMicroService.Services
{
    public interface IServiceEstudiante
    {
        IQueryable<Object> GetAll();
        Estudiante GetEstudiante(string id);
        bool SaveEstudiante(Estudiante estudiante);
        bool UpdateEstudiante(string id, Estudiante estudiante);
        bool BajaEstudiante(string id);
    }
}
