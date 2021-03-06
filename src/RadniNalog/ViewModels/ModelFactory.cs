﻿using Microsoft.EntityFrameworkCore;
using RadniNalog.Data;
using RadniNalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ViewModels
{
    public class ModelFactory
    {
        

       

        public static AutomobilViewModel GetAutomobilVM(Automobil auto)
        {
            return new AutomobilViewModel
            {
                ID = auto.ID,
                Registracija = auto.Registracija

            };

        }

        public static MjestoRadaViewModel GetMjestoRadaVM(MjestoRada mRada)
        {
           
            
            return new MjestoRadaViewModel
            {
                ID = mRada.ID,
               Ime = mRada.Ime,
               PodrucjeID = mRada.PodrucjeID,
               Podrucje = mRada.Podrucje.Ime,
               TipPostrojenja = mRada.TipPostrojenja.Naziv,
               DASime = mRada.TipDas.Ime

            };

        }

        public static MjestoRadaViewModel GetMjestoRadaVMDIRECT(MjestoRada mRada)
        {


            return new MjestoRadaViewModel
            {
                ID = mRada.ID,
                Ime = mRada.Ime,
                PodrucjeID = mRada.PodrucjeID,
                Podrucje = mRada.Podrucje.Ime,
                TipPostrojenja = mRada.TipPostrojenja.Naziv,
                DASime = mRada.TipDas.Ime

            };

        }

        public static VrstRadaViewModel GetVrstaVM(VrstaRada mRada)
        {
            return new VrstRadaViewModel
            {
                ID = mRada.ID,
                Sifra = mRada.Sifra,
               Naziv = mRada.Naziv

            };

        }


        public static List<RNalogViewModel> GetRNalozi(List<RNalog> lista)
        {
            List<RNalogViewModel> pocetnaLista = new List<RNalogViewModel>();

            lista.ForEach(m =>
            {
                RNalogViewModel nalogVM = new RNalogViewModel
                {
                    ID = m.ID,
                    Automobil = ModelFactory.GetAutomobilVM(m.Automobil),
                    //Datum = m.Datum.ToString("dd-MM-yyyy"),
                    RadVezanUZ = m.RadVezanUZ,
                    Prilog = m.Prilog,
                    Napomena = m.Napomena,
                    RadniZadatakBroj = m.RadniZadatakBroj,
                    KategorijaRada = m.KategorijaRada,
                    TipRada = m.TipRada,
                    ObukaZaposlenika = m.ObukaZaposlenika,
                    OsiguranjeMjestaRada = m.OsiguranjeMjestaRada,
                    IspraveZaRad = m.IspraveZaRad,
                    NadzorZaposlenika = m.NadzorZaposlenika,
                    PocetakRadova = m.PocetakRadova,
                    KrajRadova = m.KrajRadova,
                    LokacijaRada = m.LokacijaRada,
                    Datum = m.Datum,
                    Izvrsitelj2 = m.Izvrsitelj2,
                    Izvrsitelj3 = m.Izvrsitelj3,
                    Materijal = m.Materijal,
                    MjestoRada = ModelFactory.GetMjestoRadaVM(m.MjestoRada),
                    OpisRadova = m.OpisRadova,
                    PutniNalog = m.PutniNalog,
                    Rukovoditelj = m.Rukovoditelj,
                    VrstaRada = ModelFactory.GetVrstaVM(m.VrstaRada),
                    IzvjOpisIzvRadova = m.IzvjOpisIzvRadova,
                    IzvjNeizvedeniRadovi = m.IzvjNeizvedeniRadovi,
                    IzvjUoceniNedostaci = m.IzvjUoceniNedostaci,
                    IzvjNapomena = m.IzvjNapomena,
                    IzvjRadnoVrijeme = m.IzvjRadnoVrijeme,
                    IzvjPrijevoz = m.IzvjPrijevoz,
                    IzvjIzdatnice = m.IzvjIzdatnice,
                    IzvjPovratnice = m.IzvjPovratnice,
                    IzvjOstaliTroskovi = m.IzvjOstaliTroskovi,
                    IzvjPrimio = m.IzvjPrimio,
                    IzvjPodnio = m.IzvjPodnio,
                    IzvjPreglEvident = m.IzvjPreglEvident



                };

                pocetnaLista.Add(nalogVM);


            });


            return pocetnaLista;

        }


    }
}
