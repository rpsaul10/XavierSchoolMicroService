using System;
using System.Collections.Generic;

#nullable disable

namespace XavierSchoolMicroService.Models
{
    public partial class Profesore
    {
        public Profesore()
        {
            Leccionprivada = new HashSet<Leccionprivadum>();
            Leccionpublicas = new HashSet<Leccionpublica>();
        }

        public int IdProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public string ApellidoProfesor { get; set; }
        public DateTime? FechaNacimientopr { get; set; }
        public string NssProfesor { get; set; }
        public byte? ActivoOInactivo { get; set; }

        public virtual ICollection<Leccionprivadum> Leccionprivada { get; set; }
        public virtual ICollection<Leccionpublica> Leccionpublicas { get; set; }
    }
}
