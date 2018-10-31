using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class TipDas
    {
        public int ID { get; set; }
        public string Ime { get; set; }

        public ICollection<MjestoRada> MjestaRada { get; set; }

    }
}
