using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XavierSchoolMicroService.Utilities;
using XavierSchoolMicroService.Models;
using XavierSchoolMicroService.Services;
using Microsoft.AspNetCore.DataProtection;

namespace XavierSchoolMicroService.Bussiness
{
    public class ServiceEstudiante : IServiceEstudiante
    {
        private readonly escuela_xavierContext _context;
        private const string PURPOSE = "EstudiantesProtection";

        private readonly IDataProtector _protector;

        public ServiceEstudiante (escuela_xavierContext context, IDataProtectionProvider provider)
        {
            _context = context;
            _protector = provider.CreateProtector(PURPOSE);
        }

        public bool BajaEstudiante(string id)
        {
            throw new NotImplementedException();
        }

        public List<FinalEstudiante> GetAll()
        {
            try
            {
                var estuds = from est in _context.Estudiantes.Skip(2).Take(4)
                             join dorm in _context.Dormitorios on est.FkDormitorioEst equals dorm.IdDormitorio
                             join niv in _context.Nivelpoders on est.FkNivelpoderEst equals niv.IdNivel
                            select new FinalEstudiante(
                                est.IdEstudiante.ToString(),
                                est.NombreEstudiante,
                                est.ApellidoEstudiante,
                                est.FechaNacimiento,
                                est.NombreEstudiante,
                                est.ActivoOInactivo,
                                FinalEstudiante.BuildDicDormitorio(dorm.NumeroDpto, dorm.Piso),
                                niv.NombreNivel
                            );
                            //  select new
                            //  {
                            //     IdEst = est.IdEstudiante,
                            //     NombreEstudiante = est.NombreEstudiante,
                            //     ApellidoEstudiante = est.ApellidoEstudiante,
                            //     FechaNacimiento = est.FechaNacimiento,
                            //     NssEstudiante = est.NssEstudiante,
                            //     Activo = est.ActivoOInactivo,
                            //     Dormitorio = $"Departamento: {dorm.NumeroDpto} Piso: {dorm.Piso}",
                            //     Nivel = niv.NombreNivel
                            //  };
                List<FinalEstudiante> tempEstuds = new List<FinalEstudiante>();
                foreach (var e in estuds)
                {
                    tempEstuds.Add(e);
                }
                foreach (var est in tempEstuds)
                {
                    var estud_whit_powers = from poder in _context.Poderes
                                        join pod_estu in _context.PoderesEstudiantes
                                        on poder.IdPoder equals pod_estu.FkPoderEst
                                        where pod_estu.FkEstudiantePod == int.Parse(est.IdEst)
                                        select poder.NombrePoder;
                    // Console.WriteLine("si");
                    //Console.WriteLine(estud_whit_powers.First());
                    List<string> powers = new List<string>();
                    foreach (var po in estud_whit_powers) {
                        powers.Add(po);
                    }
                    est.powers = powers;
                    est.IdEst = _protector.Protect(est.IdEst);
                    // finalList.Add(new {
                    //     NombreEstudiante = est.NombreEstudiante,
                    //     ApellidoEstudiante = est.ApellidoEstudiante,
                    //     FechaNacimiento = est.FechaNacimiento,
                    //     NssEstudiante = est.NssEstudiante,
                    //     Activo = est.Activo,
                    //     Dormitorio = est.Dormitorio,
                    //     Nivel = est.Nivel,
                    //     PowersList = powers
                    // });
                }

                //Console.WriteLine(finalList.Count);
                
                return tempEstuds;
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