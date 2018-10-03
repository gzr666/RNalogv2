(function () {

    angular.module("appAdmin").factory("zaposlenikService", function ($http, $q) {


        var saveZaposlenik = function (zaposlenik) {

            var q = $q.defer();

            $http.post("/api/zaposlenici", zaposlenik).then(
               function (data) {


                   q.resolve(data.data);

               },
            function (error) {

                q.reject(error);
            });

            return q.promise;


        };

        var deleteZaposlenik = function (id)
        {
            var q = $q.defer();

            $http({
                method: 'DELETE',
                url: '/api/zaposlenici/' + id
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

        var updateZaposlenik = function (zaposlenik)
        {
            var q = $q.defer();
            $http({
                method: 'PUT',
                url: '/api/zaposlenici/' + zaposlenik.id,
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

        var getZaposlenik = function (id)
        {
            var q = $q.defer();
            var url = "/api/zaposlenici/" + id;
            $http.get(url).then(
                function (data) {

                    q.resolve(data.data);

                },
                function (error) {
                    q.reject(error);


                })

            return q.promise;


        }


        var postRN = function (rnalog) {

            var config = { responseType: 'blob' };
            var q = $q.defer();
            var url = "/api/pdf/pdfNalogROT2";
            $http.post(url,rnalog, config).then(
                function (data) {

                    q.resolve(data);

                },
                function (error) {
                    q.reject(error);


                })

            return q.promise;


        }


        var getZaposlenici = function () {

            var q = $q.defer();
            var url = "/api/zaposlenici/";
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

            postZaposlenik: saveZaposlenik,
            deleteZaposlenik: deleteZaposlenik,
            editZaposlenik: updateZaposlenik,
            dohvatiZaposlenika: getZaposlenik,
            postRN: postRN,
            getZaposlenici:getZaposlenici

        }


    });


}());