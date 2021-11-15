using System.Linq;
using XavierSchoolMicroService.Services;
using XavierSchoolMicroService.Models;

namespace XavierSchoolMicroService.Bussiness
{
    public class ServiceLecPublicas : IServiceLecPublicas
    {
        private readonly escuela_xavierContext _context;
        public ServiceLecPublicas(escuela_xavierContext context)
        {
            _context = context;
        }
        public IQueryable<object> EtudiantesPorLeccion(string id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<object> GetAll()
        {
            try
            {
                var lecciones = from lec in _context.Leccionpublicas
                                join teach in _context.Profesores on lec.FkProfesorLpub equals teach.IdProfesor
                                select CleanLecPubliData(lec, teach);

                return lecciones;
            }
            catch (System.Exception)
            {
                throw;
            }
            throw new System.NotImplementedException();
        }

        public object GetLecPublica(string id)
        {
            try
            {
                var lecciones = from lec in _context.Leccionpublicas
                                join teach in _context.Profesores on lec.FkProfesorLpub equals teach.IdProfesor
                                where lec.IdLeccionpub == int.Parse(id)
                                select CleanLecPubliData(lec, teach);
                
                if (lecciones.Count() == 0)
                    return null;
                return lecciones.First();
            }
            catch (System.Exception)
            {
                throw;
            }
            throw new System.NotImplementedException();
        }

        public static object CleanLecPubliData(Leccionpublica lec, Profesore teach)
        {
            return new {
                        IdLeccionpub = lec.IdLeccionpub,
                        NombreLeccionpub = lec.NombreLeccionpub,
                        HoraLeccionpub = lec.HoraLeccionpub == null ? null : lec.HoraLeccionpub.Value.ToString(@"hh\:mm"),
                        FechaLeccionpu = lec.FechaLeccionpu,
                        MaestroLeccionP = $"{teach.NombreProfesor} {teach.ApellidoProfesor}"
                    };
        }
    }
}