using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class TipPostrojenja
    {
        //tipovi postrojenja(110/35,35/10,10/0.4,ostalo)

        public int ID { get; set; }

        public string Naziv { get; set; }

        //nav props
        public ICollection<MjestoRada> MjestaRada { get; set; }
    }
}

