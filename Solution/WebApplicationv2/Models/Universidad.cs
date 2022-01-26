using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationv2.Models
{
    public partial class Universidad
    {
        public Universidad()
        {
            Carrera = new HashSet<Carrera>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fundacion { get; set; }
        public string Dominio { get; set; }

        public virtual ICollection<Carrera> Carrera { get; set; }
    }
}
