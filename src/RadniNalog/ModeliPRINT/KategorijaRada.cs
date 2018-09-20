using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ModeliPRINT
{
   [Owned]
    public class KategorijaRada
    {
      
        public bool BeznaponskoStanje{get;set;}
        public bool BlizinaNapona { get; set; }
    }
}
