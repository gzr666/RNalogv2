using RadniNalog.ModeliPRINT;
using RadniNalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ViewModels
{
    public class RNalogViewModel
    {
        public int ID { get; set; }
        public String Datum { get; set; }
        public string OpisRadova { get; set; }
        public string Materijal { get; set; }
        public string RadVezanUZ { get; set; }
        public string Prilog { get; set; }
        public string Napomena { get; set; }
        public string RadniZadatakBroj { get; set; }
        public string LokacijaRada { get; set; }

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




        //public string Rukovoditelj { get; set; }
        //public string Izvrsitelj2 { get; set; }
        //public string Izvrsitelj3 { get; set; }
        //public string PutniNalog { get; set; }
        public Zaposlenik Rukovoditelj { get; set; }
        public Zaposlenik Izvrsitelj2 { get; set; }
        public Zaposlenik Izvrsitelj3 { get; set; }
        public string PutniNalog { get; set; }
        public AutomobilViewModel Automobil{get;set;}
        public VrstRadaViewModel VrstaRada { get; set; }
        public MjestoRadaViewModel MjestoRada { get; set; }
    }
}
