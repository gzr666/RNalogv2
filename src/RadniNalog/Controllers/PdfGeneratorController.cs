using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadniNalog.Data;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using RadniNalog.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Rotativa.AspNetCore;
using RadniNalog.Models;

namespace RadniNalog.Controllers
{

    [Route("api/pdf")]
    public  class PdfGeneratorController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public PdfGeneratorController(ApplicationDbContext context, IHostingEnvironment env)
        {

            _context = context;
            _env = env;


        }


        //public IActionResult IndexPDF()
        //{
        //    var lista = _context.Zaposlenici.ToList();
        //    this.Response.Headers.Add("Content-Encoding", "win-1250");


        //    return ViewPdf(lista,"/Views/Home/View");


        //}


        [HttpGet("listaNaloga")]
        public  async Task<IActionResult> ListaZaposlenika([FromServices] INodeServices nodeServices)
        {


            var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi
                .Include(v => v.VrstaRada).
                 Include(m => m.MjestoRada).ThenInclude(mj => mj.Podrucje).
               Include(m => m.MjestoRada).ThenInclude(mj => mj.TipDas). Include(m => m.MjestoRada).ThenInclude(mj => mj.TipPostrojenja)
               .Include(a => a.Automobil).ToList());

           

            


            HttpContext.Response.ContentType = "application/pdf";

            string filename = @"report.pdf";
            HttpContext.Response.Headers.Add("x-filename", filename);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-filename");

            var result = await nodeServices.InvokeAsync<byte[]>("./pdf",nalozi);
            HttpContext.Response.Body.Write(result, 0, result.Length);
            return  new ContentResult();
        }

        
        [HttpGet("pdfNalog/{id}")]
        public async Task<IActionResult> ZaposlenikSingle([FromServices] INodeServices nodeServices, [FromRoute] int id)
        {

            var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil).ToList());


            var single = nalozi.SingleOrDefault(m => m.ID == id);




            var result = await nodeServices.InvokeAsync<byte[]>("./pdfSingle", single);

            HttpContext.Response.ContentType = "application/pdf";

            string filename = @"report.pdf";
            HttpContext.Response.Headers.Add("x-filename", filename);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-filename");
            HttpContext.Response.Body.Write(result, 0, result.Length);
            return new ContentResult();
        }


        //igra sa rotativom

        [HttpGet("pdfNalogROT/{id}")]
        public  IActionResult ZaposlenikSingleROTATIVAAsync([FromRoute] int id)
        {
            var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil).ToList());


            var single = nalozi.SingleOrDefault(m => m.ID == id);



            return  new ViewAsPdf("SingleROTATIVA",single)
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                PageSize = Rotativa.AspNetCore.Options.Size.A4


            };



        }




        [HttpGet]
        public async Task<IActionResult> Excel()
        {

            


            string webRoot = _env.WebRootPath;
            string filename = @"demo1.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, filename);
            FileInfo file = new FileInfo(Path.Combine(webRoot, filename));

            ViewBag.URLEXCEL = URL;

            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(webRoot, filename));
            }

            // var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil).ToList());

            var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi
                .Include(v => v.VrstaRada).
                 Include(m => m.MjestoRada).ThenInclude(mj => mj.Podrucje).
               Include(m => m.MjestoRada).ThenInclude(mj => mj.TipDas).Include(m => m.MjestoRada).ThenInclude(mj => mj.TipPostrojenja).
             Include(izvr => izvr.Rukovoditelj)
               .Include(izvr2 => izvr2.Izvrsitelj2)
               .Include(izvr3 => izvr3.Izvrsitelj3)
               .Include(a => a.Automobil).ToList());


            var count = nalozi.Count;


            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(webRoot, filename), FileMode.Create, FileAccess.Write))
            {
               
               IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Nalozi");
               
                IRow row = excelSheet.CreateRow(0);
                


                //header row
                row.CreateCell(0).SetCellValue("ID");
                row.CreateCell(1).SetCellValue("Datum");
                row.CreateCell(2).SetCellValue("Opis Radova");
                row.CreateCell(3).SetCellValue("Materijal");
                row.CreateCell(4).SetCellValue("Rukovoditelj");
                row.CreateCell(5).SetCellValue("Izvrsitelj1");
                row.CreateCell(6).SetCellValue("Izvrsitelj2");
               // row.CreateCell(7).SetCellValue("Putni Nalog");
                row.CreateCell(7).SetCellValue("Automobil");
                row.CreateCell(8).SetCellValue("Vrsta Rada");
                row.CreateCell(9).SetCellValue("Mjesto Rada");


                for (int i = 0; i < count; i++)
                {
                    row = excelSheet.CreateRow(i + 1);
                   


                    //ispraviti excel
                    row.CreateCell(0).SetCellValue(nalozi.ElementAt(i).ID);
                    row.CreateCell(1).SetCellValue(nalozi.ElementAt(i).Datum);
                    row.CreateCell(2).SetCellValue(nalozi.ElementAt(i).OpisRadova);
                    row.CreateCell(3).SetCellValue(nalozi.ElementAt(i).Materijal);
                    row.CreateCell(4).SetCellValue(nalozi.ElementAt(i).Rukovoditelj.Ime);
                    row.CreateCell(5).SetCellValue(nalozi.ElementAt(i).Izvrsitelj2.Ime);
                    row.CreateCell(6).SetCellValue(nalozi.ElementAt(i).Izvrsitelj3.Ime);
                 //   row.CreateCell(7).SetCellValue(nalozi.ElementAt(i).PutniNalog);
                    row.CreateCell(7).SetCellValue(nalozi.ElementAt(i).Automobil.Registracija);
                    row.CreateCell(8).SetCellValue(nalozi.ElementAt(i).VrstaRada.Naziv);
                    row.CreateCell(9).SetCellValue(nalozi.ElementAt(i).MjestoRada.Ime);





                }



               

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(webRoot, filename), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);


         


        }

        [HttpGet("nalogtest")]
        public IActionResult RNGen() {

            return View();


        }

        //igra sa rotativom

        [HttpPost("pdfNalogROT2")]
        public IActionResult RN2([FromBody]  PrintRN rn)
        {

            return new ViewAsPdf("RNGen", rn)
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 5 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                PageSize = Rotativa.AspNetCore.Options.Size.A4


            };




            //return RedirectToAction("pdfNalogROT3", rn);



        }

        [HttpGet("pdfNalogROT3")]
        public IActionResult RN([FromQuery]PrintRN rn)
        {




            return new ViewAsPdf("RNGen", rn)
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 5 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                PageSize = Rotativa.AspNetCore.Options.Size.A4


            };







        }


        //igra sa rotativom

        [HttpGet("kreirajPDF/{id}")]
        public IActionResult KreirajNalogPDFAsync([FromRoute] int id)
        {
            //var nalozi2 = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada)
            //    .Include(m => m.MjestoRada)
            //    .Include(a => a.Automobil)
            //    .Include(izvr=>izvr.Rukovoditelj)
            //    .Include(izvr2 => izvr2.Izvrsitelj2)
            //    .Include(izvr3 => izvr3.Izvrsitelj3)
            //    .Include(katrada=>katrada.KategorijaRada)
            //    .ToList());

            var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi
               .Include(v => v.VrstaRada).
                Include(m => m.MjestoRada).ThenInclude(mj => mj.Podrucje).
              Include(m => m.MjestoRada).ThenInclude(mj => mj.TipDas).Include(m => m.MjestoRada).ThenInclude(mj => mj.TipPostrojenja)
              .Include(a => a.Automobil).
               Include(izvr => izvr.Rukovoditelj)
               .Include(izvr2 => izvr2.Izvrsitelj2)
               .Include(izvr3 => izvr3.Izvrsitelj3).ToList());


            var single = nalozi.SingleOrDefault(m => m.ID == id);

           

            return new ViewAsPdf("RNGen", single)
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                


            };



        }


        //igra sa rotativom

        [HttpGet("kreirajPDFList")]
        public IActionResult KreirajNalogPDFListAsync()
        {
            //var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada)
            //    .Include(m => m.MjestoRada)
            //    .Include(a => a.Automobil)
            //    .Include(izvr => izvr.Rukovoditelj)
            //    .Include(izvr2 => izvr2.Izvrsitelj2)
            //    .Include(izvr3 => izvr3.Izvrsitelj3)
            //    .Include(katrada => katrada.KategorijaRada)
            //    .ToList());


            var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).
               Include(m => m.MjestoRada).ThenInclude(mj => mj.Podrucje).
               Include(m => m.MjestoRada).ThenInclude(mj => mj.TipDas).
               Include(m => m.MjestoRada).ThenInclude(mj => mj.TipPostrojenja).
               Include(a => a.Automobil).
               Include(izvr => izvr.Rukovoditelj)
               .Include(izvr2 => izvr2.Izvrsitelj2)
               .Include(izvr3 => izvr3.Izvrsitelj3)
               .Include(katrada => katrada.KategorijaRada).

               ToList());


            //var single = nalozi.SingleOrDefault(m => m.ID == id);



            return new ViewAsPdf("RNGenLIST", nalozi)
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                PageSize = Rotativa.AspNetCore.Options.Size.A4


            };



        }

    }
}