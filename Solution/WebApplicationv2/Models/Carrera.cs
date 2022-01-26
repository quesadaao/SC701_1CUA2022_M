using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationv2.Models
{
    public partial class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string GradoAcademico { get; set; }
        public bool? AcreditadaSinaes { get; set; }
        public DateTime? Creacion { get; set; }
        public string Decano { get; set; }
        public int? Precio { get; set; }
        public string RequisitoGraduacion { get; set; }
        public bool? Desactivado { get; set; }
        public int? IdUniversidad { get; set; }

        public virtual Universidad IdUniversidadNavigation { get; set; }
    }
}
