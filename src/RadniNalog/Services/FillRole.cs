using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RadniNalog.Data;
using RadniNalog.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Services
{
    public  class FillRole : IFillRole
    {
        private  ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _signinManager;
        private  UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;


        public FillRole(ApplicationDbContext context,RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHostingEnvironment env)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signInManager;
            _env = env;


        }



        //public  void fillNalog()
        //{

        //    //fill zaposlenika


        //    string jsonZaposlenici = @"apexbaza/zaposlenici.json";
        //    var pathToFile = Path.Combine(_env.WebRootPath, jsonZaposlenici);


        //    var parseZaposlenici = System.IO.File.ReadAllText(pathToFile);


        //    var deserZaposlenici = JsonConvert.DeserializeObject<List<ApexZaposlenik>>(parseZaposlenici);



        //    if (_context.Zaposlenici.Count() == 0)
        //    {

        //        foreach (var zaposlenik in deserZaposlenici)
        //        {
        //            Zaposlenik z = new Zaposlenik
        //            {

        //                Ime = zaposlenik.FIELD1

        //            };
        //            // _context.Zaposlenici.Add(z);
        //            _context.Entry(z).State = EntityState.Added;


        //        }

        //        _context.SaveChanges();

        //    }
        //    else
        //    {

        //    }

        //    //fill vrsta rada

        //    string jsonVrstaRada = @"apexbaza/vrstarada.json";
        //    var pathToFile2 = Path.Combine(_env.WebRootPath, jsonVrstaRada);


        //    var parseVrstaRada = System.IO.File.ReadAllText(pathToFile2);


        //    var deserVrstaRada = JsonConvert.DeserializeObject<List<ApexVrsta>>(parseVrstaRada);



        //    if (_context.VrstaRada.Count() == 0)
        //    {

        //        foreach (var vrstaRada in deserVrstaRada)
        //        {
        //            VrstaRada v = new VrstaRada
        //            {

        //                Naziv = vrstaRada.FIELD1


        //            };
        //            // _context.Zaposlenici.Add(z);
        //            _context.Entry(v).State = EntityState.Added;


        //        }

        //        _context.SaveChanges();

        //    }
        //    else
        //    {

        //    }


        //    //fill mjesta rada

        //    string jsonMjestoRada = @"apexbaza/mjestorada.json";
        //    var pathToMjestoRada = Path.Combine(_env.WebRootPath, jsonMjestoRada);


        //    var parseMjestoRada = System.IO.File.ReadAllText(pathToMjestoRada);


        //    var deserMjestoRada = JsonConvert.DeserializeObject<List<ApexMjesto>>(parseMjestoRada);



        //    if (_context.MjestoRada.Count() == 0)
        //    {

        //        foreach (var mjestoRada in deserMjestoRada)
        //        {
        //            MjestoRada m = new MjestoRada
        //            {

        //                Ime = mjestoRada.FIELD1


        //            };
        //            // _context.Zaposlenici.Add(z);
        //            _context.Entry(m).State = EntityState.Added;


        //        }

        //        _context.SaveChanges();

        //    }
        //    else
        //    {

        //    }


        //    //fill registracije

        //    string jsonRegistracija = @"apexbaza/registracija.json";
        //    var pathToRegistracija = Path.Combine(_env.WebRootPath, jsonRegistracija);


        //    var parseRegistracija = System.IO.File.ReadAllText(pathToRegistracija);


        //    var deserRegistracija = JsonConvert.DeserializeObject<List<ApexRegistracija>>(parseRegistracija);



        //    if (_context.Automobili.Count() == 0)
        //    {

        //        foreach (var registracija in deserRegistracija)
        //        {
        //            Automobil a = new Automobil
        //            {

        //                Registracija = registracija.FIELD1


        //            };
        //            // _context.Zaposlenici.Add(z);
        //            _context.Entry(a).State = EntityState.Added;


        //        }

        //        _context.SaveChanges();

        //    }
        //    else
        //    {

        //    }

        //    //fill nalozi


        //    //var autoID = 0;
        //    //var vrstaRadaID = 0;
        //    //var mjestoRadaID = 0;
        //    //string jsonRNalog = @"apexbaza/apexbaza.json";

        //    //var pathToRNalog = Path.Combine(_env.WebRootPath, jsonRNalog);

        //    //var parseRNalog = System.IO.File.ReadAllText(pathToRNalog);

        //    //var deserRNalog = JsonConvert.DeserializeObject<List<ApexSer>>(parseRNalog);


        //    //if (_context.RadniNalozi.Count() == 0)
        //    //{
        //    //    Automobil defaultAuto = new Automobil
        //    //    {

        //    //        Registracija = "Ostalo"


        //    //    };

        //    //    _context.Entry(defaultAuto).State = EntityState.Added;


        //    //    VrstaRada defaultVrsta = new VrstaRada
        //    //    {
        //    //        Naziv = "Ostalo"



        //    //    };

        //    //    _context.Entry(defaultVrsta).State = EntityState.Added;



        //    //    MjestoRada defaultMjesto = new MjestoRada
        //    //    {

        //    //        Ime = "Ostalo"

        //    //    };

        //    //    _context.Entry(defaultMjesto).State = EntityState.Added;


        //    //    foreach (var rNalog in deserRNalog)


        //    //    {






        //    //        var auto = _context.Automobili.Where(automobil => automobil.Registracija == rNalog.FIELD11).FirstOrDefault();

        //    //        if (auto == null)
        //    //        {
        //    //            autoID = defaultAuto.ID;

        //    //        }
        //    //        else {

        //    //            autoID = auto.ID;
        //    //        }

        //    //        var vRad = _context.VrstaRada.Where(vRada => vRada.Naziv == rNalog.FIELD3).FirstOrDefault();

        //    //        if (vRad == null)
        //    //        {
        //    //            vrstaRadaID = defaultVrsta.ID;

        //    //        }
        //    //        else
        //    //        {

        //    //            vrstaRadaID = vRad.ID;
        //    //        }

        //    //        var mRad = _context.MjestoRada.Where(mRada => mRada.Ime == rNalog.FIELD2).FirstOrDefault();

        //    //        if (mRad == null)
        //    //        {
        //    //            mjestoRadaID = defaultMjesto.ID;

        //    //        }
        //    //        else
        //    //        {

        //    //            mjestoRadaID = mRad.ID;
        //    //        }




        //    //        RNalog nalog = new RNalog
        //    //        {

        //    //           OpisRadova = rNalog.FIELD4,
        //    //           Materijal = rNalog.FIELD5,
        //    //           Rukovoditelj = rNalog.FIELD7,
        //    //           Izvrsitelj2 = rNalog.FIELD8,
        //    //           Izvrsitelj3 = rNalog.FIELD9,
        //    //           PutniNalog = rNalog.FIELD10,
        //    //           AutomobilID = autoID,
        //    //           VrstaRadaID = vrstaRadaID,
        //    //           MjestoRadaID = mjestoRadaID,
        //    //           Datum = rNalog.FIELD6



        //    //        };
        //    //        // _context.Zaposlenici.Add(z);
        //    //        _context.Entry(nalog).State = EntityState.Added;


        //    //    }

        //    //    _context.SaveChanges();

        //    //}
        //    //else
        //    //{

        //    //}









        //    /*if (_context.RadniNalozi.Count() == 0)
        //    {
        //        //test json-a
        //        string jsonname = @"apexbaza/apexbaza.json";
        //        var pathToFile = Path.Combine(_env.WebRootPath, jsonname);


        //        var test2 = System.IO.File.ReadAllText(pathToFile);

        //        var test = JsonConvert.DeserializeObject<List<ApexSer>>(test2);




        //     }

        //    else {

        //        return;
        //    }*/

        //}

        public void  testFill()
        {

            //fill podrucja
            if (_context.Podrucja.Count() == 0)
            {
                List<Podrucje> listaPodrucja = new List<Podrucje> {

                new Podrucje { Ime = "Split" },
                new Podrucje { Ime="Zadar"},
                new Podrucje { Ime="Šibenik"},
                new Podrucje { Ime = "Dubrovnik"}



                };


           
                foreach (var podrucje in listaPodrucja)
                {
                    _context.Podrucja.Add(podrucje);
                    _context.Entry(podrucje).State = EntityState.Added;



                }

               _context.SaveChanges();
              
            }
            else { }


            //fill tipovi das-a
            if (_context.TipoviDas.Count() == 0)
            {
                List<TipDas> listaDAS = new List<TipDas> {

                    new TipDas{Ime="Advantech 510"},
                    new TipDas{Ime="Advantech 610"},
                    new TipDas{Ime="ARK-2120F"},
                    new TipDas{Ime="AVA 8B"},
                    new TipDas{Ime="CJ-20 IEL"},
                    new TipDas{Ime="DS 2000"},
                    new TipDas{Ime="DS 802"},
                    new TipDas{Ime="DSR 100"},
                    new TipDas{Ime="DSSN 200"},
                    new TipDas{Ime="RTU 520"},
                    new TipDas{Ime="RTU 560"},
                    new TipDas{Ime="UST-10Gc"}



                };



                foreach (var das in listaDAS)
                {
                    _context.TipoviDas.Add(das);
                    _context.Entry(das).State = EntityState.Added;



                }

                _context.SaveChanges();

            }
            else { }

            //fill automobila
            if (_context.Automobili.Count() == 0)
            {
                List<Automobil> listaAuta = new List<Automobil> {

                    new Automobil{ Registracija="Dacia Dokker ST-1435 F"},
                    new Automobil{ Registracija="Dacia Dokker ST-1674 C"},
                    new Automobil{ Registracija="Dacia Sandero ST-2653 C"},
                    new Automobil{ Registracija="Fiat Doblo ST-851 PA"},
                    new Automobil{ Registracija="Fiat Panda ST-2164 C"},
                    new Automobil{ Registracija="Fiat Stilo-741 OS"},





                };



                foreach (var auto in listaAuta)
                {
                    _context.Automobili.Add(auto);
                    _context.Entry(auto).State = EntityState.Added;



                }

                _context.SaveChanges();

            }
            else { }



            //fill zaposlenici
            if (_context.Zaposlenici.Count() == 0)
            {
                List<Zaposlenik> listaZap = new List<Zaposlenik> {

                   new Zaposlenik{Ime="Branislav Vuljan"},
                   new Zaposlenik{Ime="Eduard Rusijan"},
                   new Zaposlenik{Ime="Igor Bakotić"},
                   new Zaposlenik{Ime="Ivan Maleš"},
                   new Zaposlenik{Ime="Ivica Brstilo"},
                   new Zaposlenik{Ime="Ivica Jovanović"},
                   new Zaposlenik{Ime="Ivica Radačić"},
                   new Zaposlenik{Ime="Jure Radan"},
                   new Zaposlenik{Ime="Maja Planinić"},
                   new Zaposlenik{Ime="Mario Eterovć"},
                   new Zaposlenik{Ime="Marko Sikirica"},
                   new Zaposlenik{Ime="Matko Peko"},
                   new Zaposlenik{Ime="Matko Đogaš"},
                   new Zaposlenik{Ime="Siniša Poljak"},
                   new Zaposlenik{Ime="Teo Živković"}





                };



                foreach (var zap in listaZap)
                {
                    _context.Zaposlenici.Add(zap);
                    _context.Entry(zap).State = EntityState.Added;



                }

                _context.SaveChanges();

            }
            else { }


            //fill tipovi postrojenja

            if (_context.TipoviPostrojenja.Count() == 0)
            {
                List<TipPostrojenja> TipoviPostrojenja = new List<TipPostrojenja> {

                new TipPostrojenja { Naziv = "110/10 kV"},
                new TipPostrojenja { Naziv = "110/20 kV"},
                new TipPostrojenja { Naziv = "110/35 kV"},
                new TipPostrojenja { Naziv = "110/35/10 kV"},
                new TipPostrojenja { Naziv = "220/110/35 kV"},
                new TipPostrojenja { Naziv = "35/10 kV"},
                new TipPostrojenja { Naziv="10/0.4 kV"},
                new TipPostrojenja { Naziv="10 LR"}


            };

                foreach (var tippostrojenja in TipoviPostrojenja)
                {
                    _context.TipoviPostrojenja.Add(tippostrojenja);
                    _context.Entry(tippostrojenja).State = EntityState.Added;


                }

                _context.SaveChanges();
                
            }
            else { }


            //fill  Aktivnosti

            if (_context.VrstaRada.Count() == 0)
            {
                //List<VrstaRada> VrsteRada = new List<VrstaRada> {

                //    new VrstaRada{ Naziv="Pregledi MR NN",Sifra="1211",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi TS 10(20)/0.4 kV",Sifra="1212",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi MR 10(20) kV",Sifra="1213",TipPregleda=121},
                //    new VrstaRada {Naziv="Pregledi TS X/10 kV",Sifra="1214",TipPregleda=121 },
                //    new VrstaRada{ Naziv="Pregledi MR 35 kV",Sifra="1215",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi MR 110 kV",Sifra="1217",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi Ostala Oprema",Sifra="1218",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi Sustava Telekomunikacija",Sifra="12181",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi Sustava MTU",Sifra="12182",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi Sustava Daljinskog Vodenja",Sifra="12183",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi Poslovno Informatickih Sustava",Sifra="12184",TipPregleda=121},
                //    new VrstaRada{ Naziv="Pregledi Sustava Mjerenja i Relejne Zastite",Sifra="12185",TipPregleda=121},

                //     new VrstaRada{ Naziv="Redovno odrzavanje MR NN",Sifra="1221",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje TS 10(20)/0.4 kV",Sifra="1222",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje MR 10(20) kV",Sifra="1223",TipPregleda=122},
                //    new VrstaRada {Naziv="Redovno odrzavanje TS X/10 kV",Sifra="1224",TipPregleda=122 },
                //    new VrstaRada{ Naziv="Redovno odrzavanje MR 35 kV",Sifra="1225",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje MR 110 kV",Sifra="1227",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje Ostala Oprema",Sifra="1228",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje Sustava Telekomunikacija",Sifra="12281",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje Sustava MTU",Sifra="12282",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje Sustava Daljinskog Vodenja",Sifra="12283",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje Poslovno Informatickih Sustava",Sifra="12284",TipPregleda=122},
                //    new VrstaRada{ Naziv="Redovno odrzavanje Sustava Mjerenja i Relejne Zastite",Sifra="12285",TipPregleda=122},

                //};

                List<VrstaRada> VrsteRada = new List<VrstaRada>
                {
                    new VrstaRada{ Naziv="Pregledi sustava Telekomunikacija",Sifra="12181",TipPregleda=121},
                    new VrstaRada{ Naziv="Pregledi sustava MTU",Sifra="12182",TipPregleda=121},
                    new VrstaRada{ Naziv="Pregledi sustava Daljinskog Vođenja",Sifra="12183",TipPregleda=121},
                   

                    new VrstaRada{ Naziv="Redovno održavanje sustava Telekomunikacija",Sifra="12281",TipPregleda=122},
                    new VrstaRada{ Naziv="Redovno održavanje sustava MTU",Sifra="12282",TipPregleda=122},
                    new VrstaRada{ Naziv="Redovno održavanje sustava Daljinskog Vođenja",Sifra="12283",TipPregleda=122},

                    new VrstaRada{ Naziv="Remont sustava Telekomunikacija",Sifra="12381",TipPregleda=123},
                    new VrstaRada{ Naziv="Remont sustava MTU",Sifra="12382",TipPregleda=123},
                    new VrstaRada{ Naziv="Remont sustava Daljinskog Vođenja",Sifra="12383",TipPregleda=123},

                    new VrstaRada{ Naziv="Modifikacije sustava Telekomunikacija",Sifra="12581",TipPregleda=125},
                    new VrstaRada{ Naziv="Modifikacije sustava MTU",Sifra="12582",TipPregleda=125},
                    new VrstaRada{ Naziv="Modifikacije sustava Daljinskog Vođenja",Sifra="12583",TipPregleda=125},

                    new VrstaRada{ Naziv="Korektivno održavanje sustava Telekomunikacija",Sifra="12681",TipPregleda=126},
                    new VrstaRada{ Naziv="Korektivno održavanje sustava MTU",Sifra="12682",TipPregleda=126},
                    new VrstaRada{ Naziv="Korektivno održavanje sustava Daljinskog Vođenja",Sifra="12683",TipPregleda=126},

                    new VrstaRada{ Naziv="Interventno održavanje sustava Telekomunikacija",Sifra="12781",TipPregleda=127},
                    new VrstaRada{ Naziv="Interventno održavanje sustava MTU",Sifra="12782",TipPregleda=127},
                    new VrstaRada{ Naziv="Interventno održavanje sustava Daljinskog Vođenja",Sifra="12783",TipPregleda=127},

                    new VrstaRada{ Naziv="Elementarne nepogode sustava Telekomunikacija",Sifra="12881",TipPregleda=128},
                    new VrstaRada{ Naziv="Elementarne nepogode sustava MTU",Sifra="12882",TipPregleda=128},
                    new VrstaRada{ Naziv="Elementarne nepogode sustava Daljinskog Vođenja",Sifra="12883",TipPregleda=128}





                };

                foreach (var vrsta in VrsteRada)
                {
                    _context.VrstaRada.Add(vrsta);
                    _context.Entry(vrsta).State = EntityState.Added;

                }

                _context.SaveChanges();

            }
            else { }


        }

        public  async Task createRolesandUsers()
        {

            if (!await _roleManager.RoleExistsAsync("SuperAdmin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

            }


            var result = await _userManager.FindByEmailAsync("imales@hep.hr");
            if (result == null)
            {
                var user = new ApplicationUser { UserName = "imales@hep.hr", Email = "imales@hep.hr" };

                var result2 = await _userManager.CreateAsync(user, "Sjetise1234@");
                if (result2.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "SuperAdmin");



                  
                }
           

            }
            


            

            


            //  var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            //  var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

           

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {


                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                

                //Here we create a Admin super user who will maintain the website  

                

                //var user = new ApplicationUser();
                //user.UserName = "Administrator";
                //user.Email = "imales@hep.hr";
                //user.EmailConfirmed = true;
             

                //string userPWD = "Sjetise1234@";

                

                //var chkUser = await _userManager.CreateAsync(user, userPWD);

                //Add default User to Role Admin   
                //if (chkUser.Succeeded)
                //{
                //    var result1 = await _userManager.AddToRoleAsync(user, "Admin");

                //}
            }

            // creating Creating Manager role    
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Korisnik"));

            }

            // creating Creating Employee role    
            if (!await _roleManager.RoleExistsAsync("Viewer"))
            {

                await _roleManager.CreateAsync(new IdentityRole("Viewer"));
            }

         //  await _context.SaveChangesAsync();
        }



    }
}
