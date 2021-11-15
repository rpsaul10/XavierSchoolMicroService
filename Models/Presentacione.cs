using System;
using System.Collections.Generic;

#nullable disable

namespace XavierSchoolMicroService.Models
{
    public partial class Presentacione
    {
        public int IdPresentacion { get; set; }
        public string NombrePresentacion { get; set; }
        public TimeSpan? HoraPresentacion { get; set; }
        public DateTime? FechaPresentacion { get; set; }
    }
}
