using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadniNalog.Services;
using Microsoft.AspNetCore.Authorization;

namespace RadniNalog.Controllers
{
    public class HomeController : Controller
    {
        public IFillRole fillrole;

        public HomeController(IFillRole fillrole)
        {

            this.fillrole = fillrole;

        }


        public IActionResult home()
        {
         


            return View();
        }



        public  IActionResult Index()
        {


            ViewBag.AppName = "myApp";
            return View();
        }

        public async Task<IActionResult> About()
        {
             await fillrole.createRolesandUsers();

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Roles ="Admin,SuperAdmin")]
        public IActionResult Administracija()
        {
            ViewBag.AppName = "appAdmin";
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
