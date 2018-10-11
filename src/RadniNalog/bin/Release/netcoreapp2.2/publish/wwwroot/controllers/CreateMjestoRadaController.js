
(function () {

    angular.module("appAdmin")
        .controller("CreateMjestoRadaController", function ($scope, $rootScope, $http, mjestoRadaService, toastr, $state, $stateParams, tipPostrojenjaService, podrucjaService, _,$timeout) {
        

            $scope.tipoviPostrojenja = [];
            $scope.podrucja = [];
            $scope.mjestoRada = {};

            //DOHVATI TIPOVE POSTROJENJA
            tipPostrojenjaService.dohvatiTipovePostrojenja().then(function (data) {
            
                angular.copy(data, $scope.tipoviPostrojenja);


            }, function () { });



            //DOHVATI PODRUCJA
            podrucjaService.dohvatiPodrucja().then(function (data) {

                angular.copy(data, $scope.podrucja);

            }, function () {



            });




            if ($stateParams.id != undefined) {

                mjestoRadaService.dohvatiMjestoRada($stateParams.id).then(function (data) {

                    $scope.mjestoRada = data;


                    $timeout(function () {

                        $scope.mjestoRada.tipPostrojenja = _.where($scope.tipoviPostrojenja, { id: data.tipPostrojenjaID })[0];
                        $scope.mjestoRada.podrucje = _.where($scope.podrucja, { id: data.podrucjeID })[0];



                    }, 2000);

                   
                }, function (error) {



                });

            }
            else { }
        

            $scope.example5customTexts = { buttonDefaultText: 'Odaberi mjesta' };

            $scope.example9model = [];

            $scope.example9data = [{ id: 1, label: "David" }, { id: 2, label: "Jhon" }, { id: 3, label: "Danny" }];

            $scope.example9settings = { enableSearch: true, smartButtonMaxItems: 1000 };

       

        

        $scope.saveMjestoRada = function (mjestoRada) {
            
            //kreirajmo mjesto rada sa potrebnim poljima
            var savemjestorada = {

                ime: mjestoRada.ime,
                PodrucjeID: mjestoRada.podrucje.id,
                TipPostrojenjaID: mjestoRada.tipPostrojenja.id



            }

            mjestoRadaService.postMjestoRada(savemjestorada).then(function (data) {

                toastr.success('Uspjesno kreirano Mjesto Rada', '',
                    {
                        onHidden: function () { $state.go("admin"); }
                    });
             

            }, function (error) {
                console.log(error);

                toastr.error('Ispravi greške pri unosu', '');

            })

        };

        $scope.editMjestoRada = function (mjestoRada) {

            console.log(mjestoRada);
           
            var savemjestorada2 = {

                ime: mjestoRada.ime,
                PodrucjeID: mjestoRada.podrucje.id,
                TipPostrojenjaID: mjestoRada.tipPostrojenja.id,
                id:mjestoRada.id


            }


            mjestoRadaService.editMjestoRada(savemjestorada2).then(function (data) {

                toastr.success('Uspjesno izmijenjeno mjesto rada', '',
                    {
                        onHidden: function () { $state.go("admin"); }
                    });


            }, function (error) {
                console.log(error);

                toastr.error('Ispravi greške pri unosu', '');

            })


                

        }





    });


}());