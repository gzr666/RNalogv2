
(function () {

    angular.module("myApp")
        .controller("EditNalogController", function ($scope, $rootScope, $http, $filter, ngTableParams, toastr, $state, $stateParams, _,
            automobilService, vrstaRadaService, mjestoRadaService, zaposlenikService, nalogService) {
        

      
       
        $scope.users = [];

        $scope.rukovoditelji = [];
        $scope.izvrsitelji1 = [];
        $scope.izvrsitelji2 = [];
        $scope.pNalozi = [{ id: 1, name: "DA" }, { id: 2, name: "NE" }];
        $scope.mjestaRada = [];
        $scope.vrsteRada = [];
        $scope.automobili = [];
        $scope.rnalog = {};
        $scope.spremnik = {};
        $scope.testMe = {};



        //dohvati mjesta rada

        mjestoRadaService.getMjestaRada().then(function (data) {

            angular.copy(data, $scope.mjestaRada);


        }, function (error) {


        });

        //dohvati vrste rada
     
        vrstaRadaService.getVrsteRada().then(function (data) {

            angular.copy(data, $scope.vrsteRada);



        }, function (error) {


        });


        //dohvati automobile

        automobilService.getAutomobili().then(function (data) {

            angular.copy(data, $scope.automobili);



        }, function (error) {


        });
        



        //dohvati zaposlenike


        zaposlenikService.getZaposlenici().then(function (data) {



            console.log(data);
            angular.copy(data, $scope.rukovoditelji);
            angular.copy(data, $scope.izvrsitelji1);
            angular.copy(data, $scope.izvrsitelji2);
            console.log($scope.izvrsitelji1);


        }, function (error) {


        });



        //dohvati nalog za edit
        nalogService.getNalozi().then(function (data) {

           
          
          //  angular.copy(data, $scope.rnalog);

           

            //$scope.spremnik.rukovoditelj = _.where($scope.rukovoditelji, { ime:data.rukovoditelj })[0];
            //$scope.spremnik.izvrsitelj1 = _.where($scope.izvrsitelji1, { ime:data.izvrsitelj2 })[0];
            //$scope.spremnik.izvrsitelj2 = _.where($scope.izvrsitelji2, { ime:data.izvrsitelj3 })[0];
            //$scope.spremnik.nalog = _.where($scope.pNalozi, { name: data.putniNalog })[0];
            //$scope.spremnik.mjestoRada = _.where($scope.mjestaRada, { id:data.mjestoRadaID })[0];
            //$scope.spremnik.vrstaRada = _.where($scope.vrsteRada, { id:data.vrstaRadaID })[0];
            //$scope.spremnik.automobil = _.where($scope.automobili, { id:data.automobilID })[0];
            //$scope.spremnik.opisRadova = data.opisRadova;
            //$scope.spremnik.materijal = data.materijal;
            //$scope.spremnik.datum = data.Datum;


         


        }, function (error) {



            });





        nalogService.getNalog($stateParams.id).then(function (data) {

            //ovdje moramo prepopulirati formu

            console.log(data);
            
            $scope.spremnik.materijal = data.materijal;
            $scope.spremnik.opisRadova = data.opisRadova;
          
        
           
            $scope.spremnik.rukovoditelj = _.where($scope.rukovoditelji, { ime: data.rukovoditelj })[0];

            $scope.spremnik.izvrsitelj1 = _.where($scope.rukovoditelji, { ime: data.izvrsitelj2 })[0];
           
           

        }, function (error) {



        });


        
           

        $scope.defRuk1 = function ()
        {
            $scope.isRuk1 = false;


        }
        $scope.defRuk2 = function () {
            $scope.isRuk2 = false;


        }
        $scope.defRuk3 = function () {
            $scope.isRuk3 = false;


        }
        $scope.defRuk4 = function () {
            $scope.isRuk4 = false;


        }
        $scope.defRuk5 = function () {
            $scope.isRuk5 = false;


        }
        $scope.defRuk6 = function () {
            $scope.isRuk6 = false;


        }
        




       

        


        //uredinalog
        $scope.urediNalog = function (spremnik)
        {
           

            console.log(spremnik);

            if (typeof spremnik.izvrsitelj1 === undefined) {
                spremnik.izvrsitelj1 = {};
                spremnik.izvrsitelj1.ime = "";
            }

            if (typeof spremnik.izvrsitelj2 === undefined) {
                spremnik.izvrsitelj2 = {};
                spremnik.izvrsitelj2.ime = "";


            }

            var rnalog = {
                ID:$stateParams.id,
                OpisRadova: spremnik.opisRadova,
                Materijal: spremnik.materijal,
                Rukovoditelj: spremnik.rukovoditelj.ime,
                Izvrsitelj2: spremnik.izvrsitelj1.ime,
                Izvrsitelj3: spremnik.izvrsitelj2.ime,
                PutniNalog: spremnik.nalog.name,
                AutomobilID: spremnik.automobil.id,
                MjestoRadaID: spremnik.mjestoRada.id,
                VrstaRadaID: spremnik.vrstaRada.id,
                Datum: spremnik.datum




            };

            $http({

                method: "PUT",
                url: "/api/RNalog/" + $stateParams.id,
                data: rnalog

            }).then(function (data) {

                toastr.success('Uspjesan Update Radnog Naloga', '',
                     {
                         onHidden: function () { $state.go("home"); }
                     });

            }, function (error) {

                console.log(error);
                toastr.error('Došlo je do greške...Pokušaj ponovo', '');
            });



        }

       

        

       

        


    })




    





    







    
    


}());