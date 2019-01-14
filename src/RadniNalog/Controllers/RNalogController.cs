using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadniNalog.Data;
using RadniNalog.Models;
using System.Globalization;
using RadniNalog.ViewModels;

namespace RadniNalog.Controllers
{
    [Produces("application/json")]
    [Route("api/RNalog")]
    public class RNalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RNalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RNalog
        [HttpGet]
        public IEnumerable<RNalog> GetRadniNalozi(bool includeAll=false)
        {

            if (includeAll)
            {


                return _context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil);

                

              
               

            }
            else
            {



                return _context.RadniNalozi;
            }
        }


        [HttpGet, Route("/api/statistika/putninalozi")]
        public PutniNalogStatistics GetStatisticsPutni()
        {

            return new PutniNalogStatistics
            {

                NaloziDa = _context.RadniNalozi.Where(c => c.PutniNalog == "DA").Count(),
                NaloziNe = _context.RadniNalozi.Where(c => c.PutniNalog == "NE").Count()


            };


        }

        [HttpGet, Route("/api/statistika/automobili")]
        public object GetStatisticsAutomobili()
        {

            return new
            {

                DaciaDokkerS1435F = _context.RadniNalozi.Where(c => c.Automobil.Registracija == "Dacia Dokker ST-1435 F").Count(),
                DaciaDokkerST1674C = _context.RadniNalozi.Where(c => c.Automobil.Registracija == "Dacia Dokker ST-1674 C").Count(),
                DaciaSanderoST2653C = _context.RadniNalozi.Where(c => c.Automobil.Registracija == "Dacia Sandero ST-2653 C").Count(),
                FiatDobloST851PA = _context.RadniNalozi.Where(c => c.Automobil.Registracija == "Fiat Doblo ST-851 PA").Count(),
                FiatPandaST2164C = _context.RadniNalozi.Where(c => c.Automobil.Registracija == "Fiat Panda ST-2164 C").Count(),
                FiatStilo741OS = _context.RadniNalozi.Where(c => c.Automobil.Registracija == "Fiat Stilo-741 OS").Count()




            };


        }


        [HttpGet,Route("/api/nalozi")]
        public IEnumerable<RNalogViewModel> GetRadniNalozi2(bool includeAll = false)
        {

           // var lista = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil).ToList());

            var lista = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).
                Include(m =>m.MjestoRada).ThenInclude(mj=>mj.Podrucje).
                Include(m => m.MjestoRada).ThenInclude(mj => mj.TipDas).
                Include(m => m.MjestoRada).ThenInclude(mj => mj.TipPostrojenja).
                Include(a => a.Automobil).
                Include(izvr=>izvr.Rukovoditelj)
                .Include(izvr2=>izvr2.Izvrsitelj2)
                .Include(izvr3=>izvr3.Izvrsitelj3)
                .Include(katrada=>katrada.KategorijaRada).
                
                ToList());



           
               


            return lista;
        }


        [HttpGet, Route("/api/nalozi/lokacija/{mjestoID}")]
        public IEnumerable<RNalogViewModel> GetRadniNalozi2(int mjestoID)
        {

            // var lista = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil).ToList());

            var lista = ModelFactory.GetRNalozi(_context.RadniNalozi.Where(mNalog=>mNalog.MjestoRada.ID==mjestoID).Include(v => v.VrstaRada).
                Include(m => m.MjestoRada).ThenInclude(mj => mj.Podrucje).
                Include(m => m.MjestoRada).ThenInclude(mj => mj.TipDas).
                Include(m => m.MjestoRada).ThenInclude(mj => mj.TipPostrojenja).
                Include(a => a.Automobil).
                Include(izvr => izvr.Rukovoditelj)
                .Include(izvr2 => izvr2.Izvrsitelj2)
                .Include(izvr3 => izvr3.Izvrsitelj3)
                .Include(katrada => katrada.KategorijaRada).
                OrderBy(nl=>nl.Datum).
                ToList());







            return lista;
        }

        [HttpGet, Route("/api/nalozi/{id}")]
        public RNalogViewModel GetRadniNalozi3(int id, bool includeAll = false)
        {
            var lista = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).
               Include(m => m.MjestoRada).ThenInclude(mj => mj.Podrucje).
               Include(m => m.MjestoRada).ThenInclude(mj => mj.TipDas).
               Include(m => m.MjestoRada).ThenInclude(mj => mj.TipPostrojenja).
               Include(a => a.Automobil).
               Include(izvr => izvr.Rukovoditelj)
               .Include(izvr2 => izvr2.Izvrsitelj2)
               .Include(izvr3 => izvr3.Izvrsitelj3)
               .Include(katrada => katrada.KategorijaRada).

               ToList());

            //var lista = ModelFactory.GetRNalozi(
            //    _context.RadniNalozi
               
            //    .Include(v => v.VrstaRada)
            //    .Include(m => m.MjestoRada)
            //    .Include(a => a.Automobil)
            //    .Include(ruk=>ruk.Rukovoditelj)
            //    .Include(izvr1 => izvr1.Izvrsitelj2)
            //    .Include(izvr2 => izvr2.Izvrsitelj3)
            //    .ToList());

            var single = lista.SingleOrDefault(m => m.ID == id);


            return single;
        }


        // GET: api/RNalog/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRNalog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RNalog rNalog = await _context.RadniNalozi.SingleOrDefaultAsync(m => m.ID == id);

            if (rNalog == null)
            {
                return NotFound();
            }

            return Ok(rNalog);
        }

        // PUT: api/RNalog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRNalog([FromRoute] int id, [FromBody] RNalog nalog)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nalog.ID)
            {
                return BadRequest();
            }

            //var nalog = await _context.RadniNalozi.SingleOrDefaultAsync(m => m.ID == id);



            // rNalog.Datum = rNalog.Datum;

            //  Datum = String.Format("{0:dd-MM-yyyy}", DateTime.Now)


            var rnalog2 = _context.RadniNalozi
                .Include(mjrada => mjrada.MjestoRada)
                .Include(vrada => vrada.VrstaRada)
                .Include(izvr2=>izvr2.Rukovoditelj)
                .Include(izvr3 => izvr3.Izvrsitelj2)
                .Include(aut=>aut.Automobil)
                .Include(izvr4 => izvr4.Izvrsitelj3).AsNoTracking().SingleOrDefault(rn=>rn.ID == nalog.ID);

            rnalog2.ID = nalog.ID;
            rnalog2.AutomobilID = nalog.AutomobilID;
            rnalog2.MjestoRadaID = nalog.MjestoRadaID;
            rnalog2.VrstaRadaID = nalog.VrstaRadaID;
            rnalog2.Datum = String.Format("{0:DD-MM-YYYY HH}", nalog.Datum);
            rnalog2.Izvrsitelj2.ID = nalog.Izvrsitelj2.ID;
            rnalog2.Izvrsitelj2 = nalog.Izvrsitelj2;
            rnalog2.Izvrsitelj3 = nalog.Izvrsitelj3;
            rnalog2.Izvrsitelj3.ID = nalog.Izvrsitelj3.ID;
            rnalog2.OpisRadova = nalog.OpisRadova;
            rnalog2.PutniNalog = nalog.PutniNalog;
            rnalog2.Rukovoditelj.ID = nalog.Rukovoditelj.ID;
            rnalog2.Rukovoditelj = nalog.Rukovoditelj;
            rnalog2.IspraveZaRad = nalog.IspraveZaRad;
            rnalog2.KategorijaRada = nalog.KategorijaRada;
            rnalog2.TipRada = nalog.TipRada;
            rnalog2.ObukaZaposlenika = nalog.ObukaZaposlenika;
            rnalog2.OsiguranjeMjestaRada = nalog.OsiguranjeMjestaRada;
            rnalog2.NadzorZaposlenika = nalog.NadzorZaposlenika;
            rnalog2.RadVezanUZ = nalog.RadVezanUZ;
            rnalog2.Prilog = nalog.Prilog;
            rnalog2.Napomena = nalog.Napomena;
            rnalog2.LokacijaRada = nalog.LokacijaRada;
            rnalog2.RadniZadatakBroj = nalog.RadniZadatakBroj;
            rnalog2.PocetakRadova = String.Format("{0:DD-MM-YYYY HH}", nalog.PocetakRadova);
            rnalog2.KrajRadova = String.Format("{0:DD-MM-YYYY HH}", nalog.KrajRadova);
            rnalog2.Automobil = nalog.Automobil;
            rnalog2.VrstaRada = nalog.VrstaRada;
            rnalog2.IzvjOpisIzvRadova = nalog.IzvjOpisIzvRadova;
            rnalog2.IzvjNeizvedeniRadovi = nalog.IzvjNeizvedeniRadovi;
            rnalog2.IzvjUoceniNedostaci = nalog.IzvjUoceniNedostaci;
            rnalog2.IzvjNapomena = nalog.IzvjNapomena;
            rnalog2.IzvjRadnoVrijeme = nalog.IzvjRadnoVrijeme;
            rnalog2.IzvjPrijevoz = nalog.IzvjPrijevoz;
            rnalog2.IzvjIzdatnice = nalog.IzvjIzdatnice;
            rnalog2.IzvjPovratnice = nalog.IzvjPovratnice;
            rnalog2.IzvjOstaliTroskovi = nalog.IzvjOstaliTroskovi;
            rnalog2.IzvjPrimio = nalog.IzvjPrimio;
            rnalog2.IzvjPodnio = nalog.IzvjPodnio;
            rnalog2.IzvjPreglEvident = nalog.IzvjPreglEvident;

            //RNalog nalog = new RNalog
            //{
            //    ID = rNalog.ID,
            //    Automobil = rNalog.Automobil,
            //    MjestoRada = rNalog.MjestoRada,
            //    VrstaRada = rNalog.VrstaRada,
            //    AutomobilID = rNalog.AutomobilID,
            //    Datum = String.Format("{0:DD-MM-YYYY HH}", rNalog.Datum),
            //    Izvrsitelj2 = rNalog.Izvrsitelj2,
            //    Izvrsitelj3 = rNalog.Izvrsitelj3,
            //    Materijal = rNalog.Materijal,
            //    MjestoRadaID = rNalog.MjestoRada.ID,
            //    OpisRadova = rNalog.OpisRadova,
            //    PutniNalog = rNalog.PutniNalog,
            //    Rukovoditelj = rNalog.Rukovoditelj,
            //    VrstaRadaID = rNalog.VrstaRadaID,
            //    IspraveZaRad = rNalog.IspraveZaRad,
            //    KategorijaRada = rNalog.KategorijaRada,
            //    TipRada = rNalog.TipRada,
            //    ObukaZaposlenika = rNalog.ObukaZaposlenika,
            //    OsiguranjeMjestaRada = rNalog.OsiguranjeMjestaRada,
            //    NadzorZaposlenika = rNalog.NadzorZaposlenika,
            //    RadVezanUZ = rNalog.RadVezanUZ,
            //    Prilog = rNalog.Prilog,
            //    Napomena = rNalog.Napomena,
            //    RadniZadatakBroj = rNalog.RadniZadatakBroj,
            //    PocetakRadova = String.Format("{0:DD-MM-YYYY HH}", rNalog.PocetakRadova),
            //    KrajRadova = String.Format("{0:DD-MM-YYYY HH}", rNalog.KrajRadova)





            //};


            _context.Entry(rnalog2.Rukovoditelj).State = EntityState.Modified;
            _context.Entry(rnalog2.Izvrsitelj2).State = EntityState.Modified;
            _context.Entry(rnalog2.Izvrsitelj3).State = EntityState.Modified;
            _context.Entry(rnalog2.KategorijaRada).State = EntityState.Modified;
            _context.Entry(rnalog2.TipRada).State = EntityState.Modified;
            _context.Entry(rnalog2.ObukaZaposlenika).State = EntityState.Modified;
            _context.Entry(rnalog2.OsiguranjeMjestaRada).State = EntityState.Modified;
            _context.Entry(rnalog2.IspraveZaRad).State = EntityState.Modified;
            _context.Entry(rnalog2.NadzorZaposlenika).State = EntityState.Modified;

            _context.Entry(rnalog2.Automobil).State = EntityState.Modified;

            _context.Entry(rnalog2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RNalogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok("SUCCESSFULLY edited NALOG WITH ID:" + nalog.ID);
        }

        // POST: api/RNalog
        [HttpPost]
        public async Task<IActionResult> PostRNalog([FromBody]  RNalog rNalog)
        {
            //string correctdate = rNalog.Datum.ToString();
            //DateTime dt = Convert.ToDateTime(rNalog.Datum.ToString("MM/dd/yyyy"));
            //rNalog.Datum = dt;

           
           // rNalog.Datum = DateTime.Now.ToShortDateString();
         

            //provjera ako su dodatni izvrsitelji prazni



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            Automobil auto = _context.Automobili.Where(a => a.ID == rNalog.AutomobilID).FirstOrDefault();
            MjestoRada rad = _context.MjestoRada.Where(m => m.ID == rNalog.MjestoRada.ID).FirstOrDefault();
            VrstaRada vrsta = _context.VrstaRada.Where(vr => vr.ID == rNalog.VrstaRada.ID).FirstOrDefault();

            //rNalog.Automobil = auto;
            //rNalog.MjestoRada = rad;
            //rNalog.VrstaRada = vrsta;


            // string correctdate = rNalog.Datum.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            // DateTime dt = DateTime.ParseExact(correctdate, "dd/MM/yyyy", CultureInfo.GetCultureInfoByIetfLanguageTag("hr-HR"));







            RNalog nalog = new RNalog
            {
                LokacijaRada = rNalog.LokacijaRada,
                Automobil = auto,
                MjestoRada = rad,
                VrstaRada = vrsta,
                AutomobilID = rNalog.AutomobilID,
                Datum = String.Format("{0:DD-MM-YYYY HH}", rNalog.Datum),
                Izvrsitelj2 = rNalog.Izvrsitelj2,
                Izvrsitelj3 = rNalog.Izvrsitelj3,
                Materijal = rNalog.Materijal,
                MjestoRadaID = rNalog.MjestoRada.ID,
                OpisRadova = rNalog.OpisRadova,
                PutniNalog = rNalog.PutniNalog,
                Rukovoditelj = rNalog.Rukovoditelj,
                VrstaRadaID = rNalog.VrstaRadaID,
                IspraveZaRad = rNalog.IspraveZaRad,
                KategorijaRada = rNalog.KategorijaRada,
                TipRada = rNalog.TipRada,
                ObukaZaposlenika = rNalog.ObukaZaposlenika,
                OsiguranjeMjestaRada = rNalog.OsiguranjeMjestaRada,
                NadzorZaposlenika = rNalog.NadzorZaposlenika,
                RadVezanUZ = rNalog.RadVezanUZ,
                Prilog = rNalog.Prilog,
                Napomena = rNalog.Napomena,
                RadniZadatakBroj = rNalog.RadniZadatakBroj,
                PocetakRadova = String.Format("{0:DD-MM-YYYY HH}", rNalog.PocetakRadova),
                KrajRadova = String.Format("{0:DD-MM-YYYY HH}", rNalog.KrajRadova)





            };

            Console.WriteLine(nalog.Datum);

           _context.Entry(nalog).State = EntityState.Added;

         
            //sranje koje trebaobaviti za save OWNED TIPOVA
            var katRada = _context.Entry(nalog).Reference(s => s.KategorijaRada).TargetEntry;
            katRada.State = EntityState.Added;

            var ispraveRad = _context.Entry(nalog).Reference(s => s.IspraveZaRad).TargetEntry;
            ispraveRad.State = EntityState.Added;

            var nadzorZapo = _context.Entry(nalog).Reference(s => s.NadzorZaposlenika).TargetEntry;
            nadzorZapo.State = EntityState.Added;

            var obukaZapo = _context.Entry(nalog).Reference(s => s.ObukaZaposlenika).TargetEntry;
            obukaZapo.State = EntityState.Added;

            var osiguranjeMjesta= _context.Entry(nalog).Reference(s => s.OsiguranjeMjestaRada).TargetEntry;
            osiguranjeMjesta.State = EntityState.Added;


            var tipRada = _context.Entry(nalog).Reference(s => s.TipRada).TargetEntry;
            tipRada.State = EntityState.Added;


            // _context.RadniNalozi.Add(nalog);

            try
            {
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RNalogExists(nalog.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRNalog", new { id = nalog.ID }, "success creating nalog");
        }

        // DELETE: api/RNalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRNalog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RNalog rNalog = await _context.RadniNalozi.SingleOrDefaultAsync(m => m.ID == id);
            if (rNalog == null)
            {
                return NotFound();
            }

            _context.RadniNalozi.Remove(rNalog);
            await _context.SaveChangesAsync();

            return Ok(rNalog);
        }

        private bool RNalogExists(int id)
        {
            return _context.RadniNalozi.Any(e => e.ID == id);
        }
    }
}