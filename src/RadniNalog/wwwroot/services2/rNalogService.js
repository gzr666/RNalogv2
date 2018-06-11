(function () {

    angular.module("myApp").factory("nalogService", function ($http, $q) {

        var getNalozi= function () {

            var q = $q.defer();
            var url = "/api/RNalog/";
            $http.get(url).then(
                function (data) {

                    q.resolve(data.data);

                },
                function (error) {
                    q.reject(error);


                })

            return q.promise;




        }




        var saveNalog = function (nalog) {

            var q = $q.defer();

            $http.post("/api/RNalog/", zaposlenik).then(
               function (data) {


                   q.resolve(data.data);

               },
            function (error) {

                q.reject(error);
            });

            return q.promise;


        };

        var deleteNalog = function (id)
        {
            var q = $q.defer();

            $http({
                method: 'DELETE',
                url: '/api/RNalog/' + id
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

        var updateNalog = function (nalog)
        {
            var q = $q.defer();
            $http({
                method: 'PUT',
                url: '/api/RNalog/' + zaposlenik.id,
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

        var getNalog = function (id)
        {
            var q = $q.defer();
            var url = "/api/RNalog/" + id;
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

            postNalog: saveNalog,
            deleteNalog: deleteNalog,
            editNalog: updateNalog,
            getNalog: getNalog,
            getNalozi: getNalozi

        }


    });


}());