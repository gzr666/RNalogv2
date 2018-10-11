(function () {

    angular.module("appAdmin").factory("podrucjaService", function ($http, $q) {



        var getPodrucja = function () {

            var q = $q.defer();
            var url = "/api/podrucja";
            $http.get(url).then(
                function (data) {

                    q.resolve(data.data);

                },
                function (error) {
                    q.reject(error);


                })

            return q.promise;




        }







        return {

            dohvatiPodrucja: getPodrucja

        }


    });


}());