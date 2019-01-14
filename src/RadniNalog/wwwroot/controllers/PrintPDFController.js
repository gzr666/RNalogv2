
(function () {

    angular.module("myApp")
        .controller("PrintPDFController", function ($scope, $rootScope, $http, zaposlenikService, podrucjaService, mjestoRadaService, vrstaRadaService, automobilService, toastr, $state, _, $stateParams,nalogService2) {

        var ctrl = this;
        $scope.test2 = "Radi li PRINT PDF";
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

                Trajni: false,
                Povremeni: false,
                NadzornaOsoba:""

            }



        };
        
        $scope.mjestaRada = [];
        $scope.podrucja = [];
        $scope.rukovoditelji = [];
        $scope.izvrsitelji1 = [];
        $scope.izvrsitelji2 = [];
        $scope.vrsteRada = [];
        $scope.automobili = [];
       // $scope.rnalog.Izvrsitelj2 = {};
        //$scope.rnalog.Izvrsitelj3 = {};


        $scope.rnalog.Datum = moment();


        $scope.example5customTexts = { buttonDefaultText: 'Odaberi mjesta' };

       // $scope.example9model = rnalog.MjestoRadaID;

        $scope.example9data = [];

        $scope.example9settings = { enableSearch: true, smartButtonMaxItems: 1000, selectionLimit: 1, buttonClasses:"btn" };



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



        // EDIT RADNI NALOG ZA POSTOJECI ID
        if ($stateParams.id != undefined) {

            nalogService2.getNalog($stateParams.id).then(function (data) {

                $scope.rnalog2 = {};
                angular.copy(data.data, $scope.rnalog2);

             
             

                

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

            

        }


       


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

            //$http.post("/api/pdf/pdfNalogROT2", rnalog,config).then(function (response) {

            //    var blob = response.data;
            //    var contentType = response.headers("content-type");
            //    var fileURL = URL.createObjectURL(blob);
            //    // window.open(fileURL); 
            //    newWindow.location = fileURL;

            //}, function (error) {

               
            //});


       



        };


        //provjera da nisu isti ruk i izvr
        $scope.changeRukovoditelj = function (nalog) {

            console.log($scope.rnalog);

            if ($scope.rnalog.Rukovoditelj === null || $scope.rnalog.Izvrsitelj2 === null || $scope.rnalog.Izvrsitelj3 === null) {



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




        //provjera
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
        $scope.saveNalog = function (nalog) {

            console.log(nalog);



            //if (nalog.Izvrsitelj3 == undefined) {
            //    nalog.Izvrsitelj3 = {};
            //    nalog.Izvrsitelj3.ime = "";
            //}

            //if (nalog.Izvrsitelj2 == undefined) {
            //    nalog.Izvrsitelj2 = {};
            //    nalog.Izvrsitelj2.ime = "";
            //}

            //var rnalog = {

            //    OpisRadova: nalog.OpisRadova,
            //    Materijal: nalog.Materijal,
            //    Rukovoditelj: nalog.Rukovoditelj.ime,
            //    Izvrsitelj2: nalog.Izvrsitelj2.ime,
            //    Izvrsitelj3: nalog.Izvrsitelj3.ime,
            //    PutniNalog: nalog.PutniNalog.name,
            //    AutomobilID: nalog.AutomobilID.id,
            //    MjestoRadaID: nalog.MjestoRadaID.id,
            //    VrstaRadaID: nalog.VrstaRadaID.id



            //};




            
            //HACK
            var idauto = nalog.automobilID.id;
            nalog.automobilID = idauto;

            $http.post("/api/RNalog/", nalog).then(function (data) {

                toastr.success('Uspjesno kreiran Radni Nalog', '',
                    {
                        onHidden: function () {

                            //$state.go("home");
                            window.location.href = '/#home';
                        }
                    });

            }, function (error) {

                console.log(error);

                toastr.error('Doslo je do greske...', '', {

                    onHidden: function () {

                        window.location.href = '/#home';
                    }

                });
            });


        }

    });


}());