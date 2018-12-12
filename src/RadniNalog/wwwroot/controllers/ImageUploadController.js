(function () {

    angular.module("myApp").directive('fileUpload', function () {
        return {
            scope: true,        //create a new scope
            link: function (scope, el, attrs) {
                el.bind('change', function (event) {
                    var files = event.target.files;
                    //iterate files since 'multiple' may be specified on the element
                    for (var i = 0; i < files.length; i++) {
                        //emit event upward
                        scope.$emit("fileSelected", { file: files[i] });
                    }
                });
            }
        }
    });



    angular.module("myApp")
        
        .controller("ImageUploadController", function ($scope, $http, nalogService, $stateParams) {


            $scope.files = [];

            //listen for the file selected event
            $scope.$on("fileSelected", function (event, args) {
                $scope.$apply(function () {
                    //add the file object to the scope's files collection
                    $scope.files.push(args.file);
                });
            });



           


            $scope.postImage = function (image) {

                console.log($scope.files);
                console.log($stateParams.id);

                var data = {

                    ID: $stateParams.id,
                    files: $scope.files


                };

                nalogService.postImage(data).then(function () {



                }, function () {



                    })



            }
           


        });


}());