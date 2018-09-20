using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ModeliPRINT
{
    [Owned]
    public class OsiguranjeMjestaRada
    {
        public bool VN { get; set; }
        public bool SN { get; set; }

    }
}
