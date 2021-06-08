using System;
using System.Collections.Generic;

#nullable disable

namespace SampleMVC5_0.Models
{
    public partial class Banque
    {
        public Banque()
        {
            Comptes = new HashSet<Compte>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }

        public virtual ICollection<Compte> Comptes { get; set; }
    }
}
