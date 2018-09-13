
(function () {

    angular.module("appAdmin")
    .controller("PrintPDFController", function ($scope, $rootScope, $http) {

        var ctrl = this;
        $scope.test2 = "Radi li PRINT PDF";
        //$scope.zaposlenik = {};
        $scope.rnalog = {};
        $scope.mjestaRada = [];


        //dohvati mjesta rada
        $http.get("/api/MjestoRada").success(function (data) {

            angular.copy(data, $scope.mjestaRada);



        });



        $scope.saveNalog = function (nalog) {

            var rnalog = {

                DatumNalog: $scope.datumkr._d,
                MjestoRada: nalog.MjestoRadaID.ime

                

            };

            console.log(rnalog);



            $http.post("/api/pdf/pdfNalogROT2", rnalog).then(function (data) {

               

            }, function (error) {

               
            });


       



        };



    });


}());