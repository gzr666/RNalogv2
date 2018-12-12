(function () {

    angular.module("myApp")
        .controller("IzvjestajLokacijeControllerPUBLIC", function ($scope, $rootScope, $http, toastr, $state, $stateParams, nalogService2, mjestoRadaService, ngTableParams, $filter) {

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



                    $scope.lokacijeTable = new ngTableParams(
                        {
                            page: 1,
                            count: 10
                        },
                        {
                            total: $scope.radovi.length,
                            getData: function ($defer, params) {
                                $scope.data = params.sorting() ? $filter('orderBy')($scope.radovi, params.orderBy()) : $scope.radovi;
                                $scope.data = params.filter() ? $filter('filter')($scope.data, params.filter()) : $scope.data;
                                $scope.data = $scope.data.slice((params.page() - 1) * params.count(), params.page() * params.count());
                                $defer.resolve($scope.data);
                            }
                        });



                }, function (error) {


                })


            $scope.test = $stateParams.id;


           



        })

}());