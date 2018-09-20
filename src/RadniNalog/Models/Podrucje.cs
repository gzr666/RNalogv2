using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class Podrucje
    {
        public int ID { get; set; }

        public string Ime { get; set; }


        //nav props
        public ICollection<MjestoRada> MjestaRada { get; set; }
    }
}
