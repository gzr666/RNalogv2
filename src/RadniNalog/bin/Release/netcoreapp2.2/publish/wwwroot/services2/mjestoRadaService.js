(function () {

    angular.module("myApp").factory("mjestoRadaService", function ($http, $q) {


        var getMjestaRada = function () {

            var q = $q.defer();
            var url = "/api/MjestoRada";
            $http.get(url).then(
                function (data) {

                    q.resolve(data.data);

                },
                function (error) {
                    q.reject(error);


                })

            return q.promise;




        }


        var saveMjestoRada = function (zaposlenik) {

            var q = $q.defer();

            $http.post("/api/MjestoRada", zaposlenik).then(
               function (data) {


                   q.resolve(data.data);

               },
            function (error) {

                q.reject(error);
            });

            return q.promise;


        };

        var deleteMjestoRada = function (id)
        {
            var q = $q.defer();

            $http({
                method: 'DELETE',
                url: '/api/MjestoRada/' + id
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available

                q.resolve(response.data);
              

            }, function errorCallback(response) {

                q.reject(response);
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });


            return q.promise;

        }

        var updateMjestoRada = function (zaposlenik)
        {
            var q = $q.defer();
            $http({
                method: 'PUT',
                url: '/api/MjestoRada/' + zaposlenik.id,
                data:zaposlenik
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available

                q.resolve(response.data);


            }, function errorCallback(response) {

                q.reject(response);
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });


            return q.promise;



        }

        var getMjestoRada = function (id)
        {
            var q = $q.defer();
            var url = "/api/MjestoRada/" + id;
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

            postMjestoRada: saveMjestoRada,
            deleteMjestoRada: deleteMjestoRada,
            editMjestoRada: updateMjestoRada,
            dohvatiMjestoRada: getMjestoRada,
            getMjestaRada: getMjestaRada

        }


    });


}());