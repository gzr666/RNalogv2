using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ModeliPRINT
{
    [Owned]
    public class IspraveZaRad
    {
        //public int ID { get; set; }
        public bool DopusnicaZaRad { get; set; }
        public bool DopusnicaIskljucenjeRad { get; set; }
        public bool IzjavaRukovoditelja { get; set; }

    }
}
