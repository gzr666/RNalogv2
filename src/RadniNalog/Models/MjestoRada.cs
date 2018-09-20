using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class MjestoRada
    {
        public int ID { get; set; }

        [Required]
        public string Ime { get; set; }


        //nav props
        public int TipPostrojenjaID { get; set; }
        public TipPostrojenja TipPostrojenja { get; set; }
        public int PodrucjeID { get; set; }
        public Podrucje Podrucje { get; set; }
        public ICollection<RNalog> Nalozi { get; set; }

    }
}
