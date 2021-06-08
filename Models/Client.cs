using System;
using System.Collections.Generic;

#nullable disable

namespace SampleMVC5_0.Models
{
    public partial class Client
    {
        public Client()
        {
            Comptes = new HashSet<Compte>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Compte> Comptes { get; set; }
    }
}
