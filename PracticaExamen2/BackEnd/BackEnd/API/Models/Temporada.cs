using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Temporada
    {
        public Temporada()
        {
            Capitulo = new HashSet<Capitulo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? CantidadCapitulos { get; set; }
        public DateTime? Creacion { get; set; }
        public DateTime? Modificacion { get; set; }
        public string ModificadoPor { get; set; }
        public int? IdAnime { get; set; }

        public virtual Anime IdAnimeNavigation { get; set; }
        public virtual ICollection<Capitulo> Capitulo { get; set; }
    }
}
