using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ModeliPRINT
{
    [Owned]
    public class NadzorZaposlenika
    {
        public bool Trajni { get; set; }
        public bool Povremeni { get; set; }
        public string NadzornaOsoba { get; set; }
    }
}
