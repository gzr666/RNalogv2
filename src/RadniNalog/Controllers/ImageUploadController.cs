using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadniNalog.Data;
using RadniNalog.ViewModels;
using shortid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Controllers
{
    public class ImageUploadController : Controller
    {
        private IHostingEnvironment _env;
        private readonly ApplicationDbContext _context;
        static List<string> listImages = new List<string>();

        public ImageUploadController(IHostingEnvironment env, ApplicationDbContext context)
        {

            _env = env;
            _context = context;


        }



        public IActionResult Details(int id)
        {
            var listOfImages = _context.Images.Where(image => image.LocationID == id).ToList();


            //dodajmo jos i ime lokacije kao dio viewbag-a
            var mjestoRada = _context.MjestoRada.FirstOrDefault(m => m.ID == id);

            ViewBag.ImePostrojenja = mjestoRada.Ime;
            ViewBag.IDPostrojenja = mjestoRada.ID;


            return View(listOfImages.OrderByDescending(x => x.DateAdded));
        }



        //prikazuje sve slike koje su uploadane---ne koristi se nigdi,mozda ubuduce
        public IActionResult Index()
        {
            listImages.Clear();
            FileInfo[] FileInformation = new DirectoryInfo(Path.Combine(_env.WebRootPath, "upload")).GetFiles();
            foreach (var test in FileInformation)
            {
                listImages.Add(this.Request.Scheme + "://" + this.Request.Host + "/upload/" + test.Name.ToString());


            }




            return View(listImages.OrderByDescending(x => x));
        }




        //URL ZA GET FORMU GDJE PROSLIJEDIMO ID OD LOKACIJE
        [HttpGet("/ImageUpload/Upload/{id}", Name = "UploadMyImage")]
        public IActionResult Upload(int id)
        {


            return View();
        }



        public IActionResult UploadMulti()
        {
            return View();
        }



        [HttpGet("/api/images", Name = "Images")]
        public IActionResult GetImageURLS()
        {
            listImages.Clear();
            FileInfo[] FileInformation = new DirectoryInfo(Path.Combine(_env.WebRootPath, "upload")).GetFiles();
            foreach (var test in FileInformation)
            {
                listImages.Add(this.Request.Scheme + "://" + this.Request.Host + "/upload/" + test.Name.ToString());


            }

            return Ok(listImages);


        }



        //upload form files
        [HttpPost("/{id}")]
        public async Task<IActionResult> UploadImage(IFormFile file,int id)
        {

            if (file == null || file.Length == 0)
            {
                return Content("Niste izabrali nijednu sliku");
            }

            var newFileName = ShortId.Generate() + "_" + file.FileName;
            // full path to file in temp location
            var filePath = Path.Combine(_env.WebRootPath, "upload", newFileName);
            var fileURL = this.Request.Scheme + "://" + this.Request.Host + "/upload/" + newFileName;


            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            _context.Images.Add(new ImageModel { ImagePath = fileURL, LocationID = id ,DateAdded=DateTime.Now});
            await _context.SaveChangesAsync();



            ViewBag.myid = id;

            return View("UspjesanUpload");
            // return Ok(new ImageModel{ImageName=newFileName,ImagePath=fileURL});
        }



        //upload form files
        [HttpPost("/api/postImageMulti")]
        public async Task<IActionResult> UploadImageMulti(List<IFormFile> files)
        {

            if (files == null || files.Count == 0)
            {
                return Content("file not selected");
            }


            // full path to file in temp location

            // var fileURL = this.Request.Scheme + "://" + this.Request.Host + "/upload/" + newFileName; 


            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var newFileName = ShortId.Generate() + "_" + formFile.FileName;
                    var filePath = Path.Combine(_env.WebRootPath, "upload", newFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }



            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return RedirectToRoute("Images");
            // return Ok(new ImageModel{ImageName=newFileName,ImagePath=fileURL});
        }



      
    }


}
