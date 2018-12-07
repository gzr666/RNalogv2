
(function () {

    angular.module("appAdmin")
        .controller("EditNalogController2", function ($scope, $rootScope, $http, zaposlenikService, podrucjaService, mjestoRadaService, vrstaRadaService, automobilService, toastr, $state, _, $stateParams,nalogService2,$timeout) {

            var ctrl = this;

            $scope.checkSame = false;
            $scope.dsbBTN = false;
       
        //$scope.zaposlenik = {};
        $scope.rnalog = {

            IspraveZaRad: {
                DopusnicaZaRad:false,
                DopusnicaIskljucenjeRad:false,
                IzjavaRukovoditelja:false

            },
            KategorijaRada: {

                BeznaponskoStanje: false,
                BlizinaNapona :false

            },
            TipRada: {

                Planirani: false,
                Neplanirani: false,
                Slozeni: false,
                Posebni:false

            },
            ObukaZaposlenika: {

                Strucni: false,
                Poduceni: false,
                Nepoduceni: false,
                Pripravnici:false

            },
            OsiguranjeMjestaRada: {

                VN: false,
                SN:false

            },
            NadzorZaposlenika: {

                trajni: false,
                povremeni: false,
                nadzornaOsoba:false

            }



        };
        
        $scope.mjestaRada = [];
        $scope.podrucja = [];
        $scope.rukovoditelji = [];
        $scope.izvrsitelji1 = [];
        $scope.izvrsitelji2 = [];
        $scope.vrsteRada = [];
        $scope.automobili = [];


        


        $scope.example5customTexts = { buttonDefaultText: 'Odaberi mjesta' };

       // $scope.example9model = rnalog.MjestoRadaID;

        $scope.example9data = [];

        $scope.example9settings = { enableSearch: true, smartButtonMaxItems: 1000, selectionLimit: 1, buttonClasses:"btn" };



        



        // EDIT RADNI NALOG ZA POSTOJECI ID
        if ($stateParams.id != undefined) {

            //dohvati vrste rada
            vrstaRadaService.getVrsteRada().then(function (data) {

                angular.copy(data, $scope.vrsteRada);

            }, function () {


            });

            //dohvati aute
            automobilService.getAutomobili().then(function (data) {

                angular.copy(data, $scope.automobili);


            }, function () {


            })



            //dohvati zaposlenike
            zaposlenikService.getZaposlenici().then(function (data) {




                angular.copy(data, $scope.rukovoditelji);
                angular.copy(data, $scope.izvrsitelji1);
                angular.copy(data, $scope.izvrsitelji2);



            }, function (error) {


            });



            //DOHVATI PODRUCJA
            podrucjaService.dohvatiPodrucja().then(function (data) {

                angular.copy(data, $scope.podrucja);
              

            }, function () {



            });



            //dohvati mjestarada

            mjestoRadaService.getMjestaRada().then(function (data) {

                
                angular.copy(data, $scope.mjestaRada);


            }, function () { })








            //populirajmo nalog
            nalogService2.getNalog($stateParams.id).then(function (data) {

               // $scope.rnalog = {};
                $scope.rnalog.KategorijaRada = {};
                angular.copy(data, $scope.rnalog);
                console.log(data);

                //format datuma
               var parsedDatum = moment(data.pocetakRadova).format("DD-MM-YYYY");

               

               $scope.ctrl = moment(data.datum);
               $scope.datepickerpocrad = moment(data.pocetakRadova);
               $scope.datepickerzavrad = moment(data.krajRadova);


               $timeout(function () {
                  
              
                //popuni dropdown-e
               $scope.rnalog.VrstaRada = _.where($scope.vrsteRada, { id: data.vrstaRada.id })[0];
               $scope.rnalog.automobilID = _.where($scope.automobili, { id: data.automobil.id })[0];
               $scope.rnalog.podrucjeID = _.where($scope.podrucja, { id: data.mjestoRada.podrucjeID })[0];
               $scope.rnalog.MjestoRada = _.where($scope.mjestaRada, { id: data.mjestoRada.id })[0];
               $scope.rnalog.Rukovoditelj = _.where($scope.rukovoditelji, { id: data.rukovoditelj.id })[0];
               $scope.rnalog.Izvrsitelj2 = _.where($scope.izvrsitelji1, { id: data.izvrsitelj2.id })[0];
               $scope.rnalog.Izvrsitelj3 = _.where($scope.izvrsitelji2, { id: data.izvrsitelj3.id })[0];

               }, 2000);
               $scope.rnalog.OpisRadova = data.opisRadova;
               $scope.rnalog.RadVezanUZ = data.radVezanUZ;
               $scope.rnalog.RadniZadatakBroj = data.radniZadatakBroj;
               $scope.rnalog.LokacijaRada = data.lokacijaRada;

               $scope.rnalog.KategorijaRada = data.kategorijaRada;

               console.log($scope.rnalog.KategorijaRada);

               $scope.rnalog.TipRada = data.tipRada;

               $scope.rnalog.ObukaZaposlenika = data.obukaZaposlenika;

               $scope.rnalog.OsiguranjeMjestaRada = data.osiguranjeMjestaRada;
               $scope.rnalog.IspraveZaRad = data.ispraveZaRad;

               $scope.rnalog.NadzorZaposlenika = data.nadzorZaposlenika;

               

               
             

                

            },function(){})


        }
        else { }



        


        //promjena podrucja trigger
        $scope.changePodrucje = function (podrucje) {
            console.log("change");
            console.log(podrucje.podrucjeID.id);
            mjestoRadaService.getMjestoCategory(podrucje.podrucjeID.id).then(function (data) {

                $scope.mjestaRada = [];

                console.log(data);
                //igra sa multidropom
                var test = [];

                angular.copy(data, $scope.mjestaRada);

                for (var i in data) {

                    var item = {};
                    item["id"] = data[i].id;
                    item["label"] = data[i].ime;

                    test.push(item);
                }

                $scope.example9data = test;


            }, function () { })



        };



        $scope.changeAuto = function (auto) {


          

        };
        
       


            //printanje sa BLOB TIPOM PODATAKA
        $scope.saveNalogBlob = function (nalog) {


            var config = { responseType: 'blob' };
            var newWindow = window.open();
            var rnalog = {

                DatumNalog: $scope.datumkr._d,
                MjestoRada: nalog.MjestoRadaID.ime

                

            };

            console.log(rnalog);

            zaposlenikService.postRN(rnalog).then(function (data) {

                  var blob = data.data;
                var contentType = data.headers("content-type");
               var fileURL = URL.createObjectURL(blob);
              // window.open(fileURL); 
                newWindow.location = fileURL;
              


            }, function (error) {




                })

        };


        //provjera da nisu isti ruk i izvr
        $scope.changeRukovoditelj = function (nalog) {

            console.log($scope.rnalog);

            if ($scope.rnalog.rukovoditelj === null || $scope.rnalog.Izvrsitelj2 === null || $scope.rnalog.Izvrsitelj3 === null) {



            }
            else {

                if ($scope.rnalog.Rukovoditelj.id === $scope.rnalog.Izvrsitelj2.id || $scope.rnalog.Rukovoditelj.id === $scope.rnalog.Izvrsitelj3.id) {

                 
                    $scope.checkRUK = true;
                  



                }
                else {
                    $scope.checkRUK = false;
                    console.log($scope.checkSame);
                }
               
            }



            //provjera da nemamo duplicirana imena za izvrsitelje,rukovoditelje
            if ($scope.checkRUK) {

                $scope.dsBTN = true;

            }
            else {

                $scope.dsBTN = false;


            }



        };


        //provjera da nisu isti ruk i izvr
        $scope.changeIzvrsitelj2 = function (nalog) {

            console.log($scope.rnalog);

            if ($scope.rnalog.rukovoditelj === null || $scope.rnalog.Izvrsitelj2 === null || $scope.rnalog.Izvrsitelj3 === null) {

              

            }

            else {

                if ($scope.rnalog.Izvrsitelj2.id === $scope.rnalog.Izvrsitelj3.id || $scope.rnalog.Izvrsitelj2.id === $scope.rnalog.Rukovoditelj.id) {

                    $scope.checkIZVR1 = true;
                }
                     else {
                        $scope.checkIZVR1 = false;
                   
                    }
                    

                
            }


            //provjera da nemamo duplicirana imena za izvrsitelje,rukovoditelje
            if ($scope.checkIZVR1) {

                $scope.dsBTN = true;

            }
            else {

                $scope.dsBTN = false;


            }


        };

        $scope.changeIzvrsitelj3 = function (nalog) {

            console.log($scope.rnalog);

            if ($scope.rnalog.rukovoditelj === null || $scope.rnalog.Izvrsitelj2 === null || $scope.rnalog.Izvrsitelj3 === null) {



            }
            else {

                if ($scope.rnalog.Izvrsitelj3.id === $scope.rnalog.Izvrsitelj2.id || $scope.rnalog.Izvrsitelj3.id === $scope.rnalog.Rukovoditelj.id) {

                    $scope.checkIZVR2 = true;
                }
                else {
                    $scope.checkIZVR2 = false;

                }



                
            }


            //provjera da nemamo duplicirana imena za izvrsitelje,rukovoditelje
            if ($scope.checkIZVR2) {

                $scope.dsBTN = true;

            }
            else {

                $scope.dsBTN = false;


            }


        };



        //spremanje naloga
        $scope.urediNalog = function (nalog) {



          

            console.log(nalog);

            var rnalog = {
                LokacijaRada: nalog.LokacijaRada,
                ID: nalog.id,
                Datum: nalog.datum,
                IspraveZaRad: nalog.IspraveZaRad,
                OpisRadova: nalog.OpisRadova,
                RadVezanUZ: nalog.RadVezanUZ,
                Prilog: nalog.prilog,
                Napomena: nalog.napomena,
                RadniZadatakBroj: nalog.RadniZadatakBroj,
                PocetakRadova: nalog.PocetakRadova,
                KrajRadova: nalog.KrajRadova,
                KategorijaRada: nalog.KategorijaRada,
                TipRada: nalog.TipRada,
                ObukaZaposlenika: nalog.ObukaZaposlenika,
                OsiguranjeMjestaRada: nalog.OsiguranjeMjestaRada,
               // IspraveZaRad: nalog.IspraveZaRad,
                NadzorZaposlenika: nalog.NadzorZaposlenika,
                Rukovoditelj: nalog.Rukovoditelj,
                Izvrsitelj2: nalog.Izvrsitelj2,
                Izvrsitelj3: nalog.Izvrsitelj3,
                Automobil: nalog.automobilID,
               // MjestoRada: nalog.mjestoRada,
                VrstaRada: nalog.VrstaRada,
                AutomobilID: nalog.automobilID.id,
                MjestoRadaID: nalog.MjestoRada.id,
                VrstaRadaID: nalog.VrstaRada.id





            };

            

            //var rnalog = {
            //    lokacijaRada: nalog.LokacijaRada,
            //    ID: nalog.id,
            //    Datum: nalog.datum,
            //    IspraveZaRad: nalog.IspraveZaRad,
            //    OpisRadova: nalog.OpisRadova,
            //    RadVezanUZ: nalog.RadVezanUZ,
            //    Prilog: nalog.prilog,
            //    Napomena: nalog.napomena,
            //    RadniZadatakBroj: nalog.RadniZadatakBroj,
            //    PocetakRadova: nalog.PocetakRadova,
            //    KrajRadova: nalog.KrajRadova,
            //    KategorijaRada: nalog.KategorijaRada,
            //    TipRada: nalog.TipRada,
            //    ObukaZaposlenika: nalog.ObukaZaposlenika,
            //    OsiguranjeMjestaRada: nalog.OsiguranjeMjestaRada,
            //    IspraveZaRad: nalog.IspraveZaRad,
            //    NadzorZaposlenika: nalog.NadzorZaposlenika,
            //    Rukovoditelj: nalog.Rukovoditelj,
            //    Izvrsitelj2: nalog.Izvrsitelj2,
            //    Izvrsitelj3: nalog.Izvrsitelj3,
            //    Automobil: nalog.automobil,
            //    MjestoRada: nalog.mjestoRada,
            //    VrstaRada: nalog.VrstaRada,
            //    AutomobilID: nalog.automobil.id,
            //    MjestoRadaID: nalog.MjestoRada.id,
            //    VrstaRadaID: nalog.vrstaRada.id





            //};


          


           


            nalogService2.editNalog(rnalog).then(function (data) {
                console.log("nn");
                toastr.success('Uspjesno izmijenjen Nalog', '',
                    {
                        onHidden: function () {

                            //$state.go("admin");
                            window.location.href = '/#home';
                        }
                    });


            }, function (err) {

                console.log(err);

                })

           


        }

    });


}());