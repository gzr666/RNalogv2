using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ModeliPRINT
{

    [Owned]
    public class ObukaZaposlenika
    {
        public bool Strucni { get; set; }
        public bool Poduceni { get; set; }
        public bool Nepoduceni { get; set; }
        public bool Pripravnici { get; set; }
        
    }
}
