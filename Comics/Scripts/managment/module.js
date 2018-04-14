﻿(function () {
    var app = angular.module("ComicsApp", ['ngRoute']);

    app.factory("ShareData", function () {
        return { value: 0 }
    });

    //Defining Routing
    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider.when('/showcomics',
            {
                templateUrl: 'Comic/ShowComics',
                controller: 'ComicsController'
            });
        $routeProvider.when('/createcomic',
            {
                templateUrl: 'Comic/CreateComic',
                controller: 'ComicCreateController'
            });
        $routeProvider.when("/editcomic",
            {
                templateUrl: 'Comic/EditComic',
                controller: 'ComicEditController'
            });
        $routeProvider.otherwise(
            {
                redirectTo: '/'
            });
        // $locationProvider.html5Mode(true);
        $locationProvider.html5Mode(true, false).hashPrefix('!')
    }]);

    angular.module('ComicsApp').constant('API_CONFIG', {
        url: 'http://localhost:62868/api/v1'
    });
}());