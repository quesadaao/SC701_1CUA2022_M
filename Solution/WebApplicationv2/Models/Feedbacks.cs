using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationv2.Models
{
    public partial class Feedbacks
    {
        public Feedbacks()
        {
            Vuelo = new HashSet<Vuelo>();
        }

        public int FeedbackId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool ContactMe { get; set; }

        public virtual ICollection<Vuelo> Vuelo { get; set; }
    }
}
