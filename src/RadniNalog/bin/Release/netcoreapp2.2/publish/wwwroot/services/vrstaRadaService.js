(function () {

    angular.module("appAdmin").factory("vrstaRadaService", function ($http, $q) {



        var getVrsteRada = function () {

            var q = $q.defer();
            var url = "/api/VrstaRada";
            $http.get(url).then(
                function (data) {

                    q.resolve(data.data);

                },
                function (error) {
                    q.reject(error);


                })

            return q.promise;




        }





        var saveVrstaRada = function (zaposlenik) {

            var q = $q.defer();

            $http.post("/api/VrstaRada", zaposlenik).then(
               function (data) {


                   q.resolve(data.data);

               },
            function (error) {

                q.reject(error);
            });

            return q.promise;


        };

        var deleteVrstaRada = function (id)
        {
            var q = $q.defer();

            $http({
                method: 'DELETE',
                url: '/api/VrstaRada/' + id
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

        var updateVrstaRada = function (zaposlenik)
        {
            var q = $q.defer();
            $http({
                method: 'PUT',
                url: '/api/VrstaRada/' + zaposlenik.id,
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

        var getVrstaRada = function (id)
        {
            var q = $q.defer();
            var url = "/api/VrstaRada/" + id;
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

            postVrstaRada: saveVrstaRada,
            deleteVrstaRada: deleteVrstaRada,
            editVrstaRada: updateVrstaRada,
            dohvatiVrstaRada: getVrstaRada,
            getVrsteRada: getVrsteRada

        }


    });


}());