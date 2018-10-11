(function () {

    angular.module("myApp").factory("automobilService", function ($http, $q) {


        var getAutomobili = function () {

            var q = $q.defer();
            var url = "/api/Automobil/";
            $http.get(url).then(
                function (data) {

                    q.resolve(data.data);

                },
                function (error) {
                    q.reject(error);


                })

            return q.promise;




        }


        var saveAutomobil = function (automobil) {

            var q = $q.defer();

            $http.post("/api/Automobil", automobil).then(
               function (data) {


                   q.resolve(data.data);

               },
            function (error) {

                q.reject(error);
            });

            return q.promise;


        };

        var deleteAutomobil = function (id)
        {
            var q = $q.defer();

            $http({
                method: 'DELETE',
                url: '/api/Automobil/' + id
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

        var updateAutomobil = function (automobil)
        {
            var q = $q.defer();
            $http({
                method: 'PUT',
                url: '/api/Automobil/' + automobil.id,
                data:automobil
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

        var getAutomobil = function (id)
        {
            var q = $q.defer();
            var url = "/api/Automobil/" + id;
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

            postAutomobil: saveAutomobil,
            deleteAutomobil: deleteAutomobil,
            editAutomobil: updateAutomobil,
            dohvatiAutomobil: getAutomobil,
            getAutomobili: getAutomobili

        }


    });


}());