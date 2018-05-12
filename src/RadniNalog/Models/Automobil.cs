﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class Automobil
    {
        public int ID { get; set; }

        [Required]
        public string Registracija { get; set; }

        public ICollection<RNalog> Nalozi { get; set; }
    }
}
