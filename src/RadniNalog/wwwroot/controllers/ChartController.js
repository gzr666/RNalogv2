
(function () {

    angular.module("myApp")
    .controller("chartController", function ($scope,$http) {


        $scope.options = {
            title: { display: true, text: 'Otvoreni Nalozi', position: 'bottom', padding: 5 },
            legend: { display: true, position: "bottom" }
        };

        $scope.options2 = {
            title: { display: true, text: 'Automobil/Broj Naloga', position: 'bottom', padding: 5 },
            legend: { display: false, position: "bottom" }
        };

       



        $http.get("/api/statistika/putninalozi").then(function (data) {

            $scope.labels = ["DA", "NE"];
            
            $scope.data = [data.data.naloziDa, data.data.naloziNe];


        }, function (error) {
        });


        $http.get("/api/statistika/automobili").then(function (data2) {


         
            $scope.labels2 = ["Dacia Dokker ST-1435 F", "Dacia Dokker ST-1674 C", "Dacia Sandero ST-2653 C", "Fiat Doblo ST-851 PA", "Fiat Panda ST-2164 C", "Fiat Stilo-741 OS"];
           
            $scope.data2 = [    data2.data.daciaDokkerS1435F,
                                data2.data.daciaDokkerST1674C,
                                data2.data.daciaSanderoST2653C,
                                data2.data.fiatDobloST851PA,
                                data2.data.fiatPandaST2164C,
                                data2.data.fiatStilo741OS]


        }, function (error) {
        });






        //$scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales",
        //"TestSales1", "TestSales2", "TestSales2", "TestSales2", "TestSales2"];
        //$scope.data = [300, 500, 100, 400, 1000, 800, 56, 888];


        //$scope.labels2 = ['2034', '2007', '2008', '2009', '2010', '2011', '2012'];
        //$scope.series2 = ['Series A', 'Series B'];

        //$scope.data2 = [
        //  [65, 59, 80, 81, 56, 55, 40],
        //  [28, 48, 40, 19, 86, 27, 90]
        //];



    });


}());