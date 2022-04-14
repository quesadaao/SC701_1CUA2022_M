using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.Models
{
    public partial class Anime
    {
        public Anime()
        {
            Capitulo = new HashSet<Capitulo>();
            Temporada = new HashSet<Temporada>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Creacion { get; set; }
        public DateTime? Modificado { get; set; }
        public string ModificadoPor { get; set; }

        public virtual ICollection<Capitulo> Capitulo { get; set; }
        public virtual ICollection<Temporada> Temporada { get; set; }
    }
}
