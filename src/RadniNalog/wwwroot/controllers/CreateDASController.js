
(function () {

    angular.module("appAdmin")
        .controller("CreateDASController", function ($scope, $rootScope, $http, toastr, $state, $stateParams, _, $timeout, tipDASService) {
        

            $scope.tipDasa = {};  



            //provjeri je li post ili put

            if ($stateParams.id != undefined) {

                tipDASService.getDas($stateParams.id).then(function (data) {

                    angular.copy(data, $scope.tipDasa);

                }, function (error) {



                    });

            }



            $scope.saveDAS = function (das) {


                console.log(das);
                tipDASService.postDAS(das).then(function (data) {

                    toastr.success('Uspjesno kreiran Tip Dasa', '', {
                        onHidden: function () {
                            //$state.go("admin");
                            window.location.href = '/#tipDasa';
                        }
                    });

                }, function (error) {




                })


            };


            $scope.editDAS = function (das) {

                console.log("clicked");
                tipDASService.updateDAS(das).then(function (das) {

                    console.log(das);


                }, function (error) {


                    })


            }



    });


}());