using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationv2.Models
{
    public partial class Vuelo
    {
        public int IId { get; set; }
        public string NNombreAvion { get; set; }
        public int ICantidadPasajeros { get; set; }
        public int ITipoPasajero { get; set; }
        public DateTime DtSalidadViaje { get; set; }
        public DateTime DtDestinoViaje { get; set; }
        public decimal DPesoMaximoMaletas { get; set; }
        public DateTime DtHoraSalida { get; set; }
        public DateTime DtHoraLlegada { get; set; }
        public string VAerolinea { get; set; }
        public bool BActivo { get; set; }
        public decimal DValoracionUsuarios { get; set; }
        public int? IFeedback { get; set; }

        public virtual Feedbacks IFeedbackNavigation { get; set; }
    }
}
