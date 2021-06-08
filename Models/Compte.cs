using System;
using System.Collections.Generic;

#nullable disable

namespace SampleMVC5_0.Models
{
    public partial class Compte
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Solde { get; set; }
        public int ClientId { get; set; }
        public int BanqueId { get; set; }

        public virtual Banque Banque { get; set; }
        public virtual Client Client { get; set; }
    }
}
