(function () {

    angular.module("appAdmin")
        .controller("IzvjestajLokacijeController", function ($scope, $rootScope, $http, toastr, $state, $stateParams, nalogService2, mjestoRadaService) {

            $scope.radovi = [];
            $scope.info = {};

            mjestoRadaService.getMjestoRada($stateParams.id).then(function (data) {

                angular.copy(data, $scope.info);



            }, function (err) {



                })


            nalogService2.getIzvjestajLokacije($stateParams.id)
                .then(function (data) {

                    console.log(data);

                    angular.copy(data, $scope.radovi);


                }, function (error) { })


            $scope.test = $stateParams.id;



        })

}());