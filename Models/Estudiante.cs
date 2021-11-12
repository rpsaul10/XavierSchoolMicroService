﻿using System;
using System.Collections.Generic;

#nullable disable

namespace XavierSchoolMicroService.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Leccionprivada = new HashSet<Leccionprivadum>();
        }

        public int IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public string ApellidoEstudiante { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NssEstudiante { get; set; }
        public int? FkDormitorioEst { get; set; }
        public int? FkNivelpoderEst { get; set; }
        public byte? ActivoOInactivo { get; set; }

        public virtual Dormitorio FkDormitorioEstNavigation { get; set; }
        public virtual Nivelpoder FkNivelpoderEstNavigation { get; set; }
        public virtual ICollection<Leccionprivadum> Leccionprivada { get; set; }
    }
}
