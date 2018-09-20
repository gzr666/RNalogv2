using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ModeliPRINT
{

    [Owned]
    public class TipRada
    {
        public bool Planirani { get; set; }
        public bool Neplanirani { get; set; }
        public bool Slozeni { get; set; }
        public bool Posebni { get; set; }
    }
}
