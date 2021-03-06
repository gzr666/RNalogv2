﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class VrstaRada
    {
        public int ID { get; set; }
        
        [Required]
        public string Naziv { get; set; }

        public string Sifra { get; set; }

        public int TipPregleda { get; set; }

        public ICollection<RNalog> Nalozi { get; set; }
    }
}
