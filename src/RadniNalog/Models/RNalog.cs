﻿using RadniNalog.ModeliPRINT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class RNalog
    {
        //neka radni nalog ima svog usera koji ga je napravio


        public int ID { get; set; }

        //
        public string LokacijaRada { get; set; }
        public string Datum { get; set; }
        public string OpisRadova { get; set; }
        public string Materijal { get; set; }
        //public string Rukovoditelj { get; set; }
        //public string Izvrsitelj2 { get; set; }
        //public string Izvrsitelj3 { get; set; }


        // NOVO ZA POTREBE PRINTA//

        public string RadVezanUZ { get; set; }
        public string Prilog { get; set; }
        public string Napomena { get; set; }
        public string RadniZadatakBroj { get; set; }

        // Mozda DATETIME
        public string PocetakRadova { get; set; }
        public string KrajRadova { get; set; }



        //owned types
         public KategorijaRada KategorijaRada { get; set; }
         public TipRada TipRada { get; set; }
         public ObukaZaposlenika ObukaZaposlenika { get; set; }
         public OsiguranjeMjestaRada OsiguranjeMjestaRada { get; set; }
         public IspraveZaRad IspraveZaRad { get; set; }
         public NadzorZaposlenika NadzorZaposlenika { get; set; } 

        //KRAJ PRINTA//

        public Zaposlenik Rukovoditelj { get; set; }
        public Zaposlenik Izvrsitelj2 { get; set; }
        public Zaposlenik Izvrsitelj3 { get; set; }

       // public Aktivnost Aktivnost { get; set; }


        public string PutniNalog{get;set;}


        //nav properties
        public int AutomobilID { get; set; }
        public Automobil Automobil { get; set; }


        public int MjestoRadaID { get; set; }
        public MjestoRada MjestoRada { get; set; }

        public int VrstaRadaID { get; set; }
        public VrstaRada VrstaRada { get; set; }



        //properties za IZVJESCE
        public string IzvjOpisIzvRadova { get; set; }
        public string IzvjNeizvedeniRadovi { get; set; }
        public string IzvjUoceniNedostaci { get; set; }
        public string IzvjNapomena { get; set; }
        public string IzvjRadnoVrijeme { get; set; }
        public string IzvjPrijevoz { get; set; }
        public string IzvjIzdatnice { get; set; }
        public string IzvjPovratnice { get; set; }
        public string IzvjOstaliTroskovi { get; set; }
        public string IzvjPrimio { get; set; }
        public string IzvjPodnio { get; set; }
        public string IzvjPreglEvident { get; set; }


    }
}
