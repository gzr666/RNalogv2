
(function () {

    angular.module("appAdmin")
        .controller("PrintPDFController", function ($scope, $rootScope, $http, zaposlenikService) {

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



    });


}());