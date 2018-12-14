/// <reference path="../lib/angular/angular.js" />


var myApp = angular.module("myApp", ["ui.router", 'ngTable', 'chart.js', "toastr", "720kb.datepicker", "moment-picker", "underscore", "angularMoment", "angularjs-dropdown-multiselect"]);





myApp.config(function ($stateProvider, $urlRouterProvider) {



    $urlRouterProvider.otherwise("/home");

    $stateProvider.state("home", {

        url: "/home",
        templateUrl: "../Home/home",
        controller: "HomeController"

    });

    $stateProvider.state("createNalog", {

        url: "/kreirajNalog",
        templateUrl: "../templates/createNalog.html",
        controller: "HomeController"

    });

    $stateProvider.state("editNalog", {

        url: "/editNalog/:id",
        templateUrl: "../templates/editNalog.html",
        controller: "EditNalogController"

    });
    $stateProvider.state("statistika", {

        url: "/statistika",
        templateUrl: "../templates/statistika.html",
        controller: "chartController"

    });

   
    $stateProvider.state("printPDF", {

        url: "/printPDF",
        templateUrl: "../templates/printPDF.html",
        controller: "PrintPDFController"

    });

    $stateProvider.state("editNalog2", {

        url: "/editNalog2/:id",
        templateUrl: "../templates/editNalog2.html",
        controller: "EditNalogController2"

    });

    $stateProvider.state("mjestoRada", {

        url: "/mjestoRada",
        //templateUrl: "../templates/mjestoRadaPUBLIC.html",
        templateUrl: "../templates/mjestoRadaPUBLIC.html",
        controller: "mjestoRadaControllerPUBLIC"

    });

    $stateProvider.state("izvjestajLokacije", {

        url: "/izvjestajLokacije/:id",
        templateUrl: "../templates/izvjestajLokacije.html",
        controller: "IzvjestajLokacijeControllerPUBLIC"

    });


    $stateProvider.state("imageupload", {

        url: "/imageupload/:id",
        templateUrl: "../templates/ImageUpload.html",
        controller: "ImageUploadController"

    });

    







});