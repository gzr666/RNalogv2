(function () {

    angular.module("myApp").factory("tipPostrojenjaService", function ($http, $q) {



        var getTipPostrojenja = function () {

            var q = $q.defer();
            var url = "/api/TipPostrojenja";
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

            dohvatiTipovePostrojenja: getTipPostrojenja

        }


    });


}());