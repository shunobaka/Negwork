(function() {
    'use strict';

    angular.module('negwork.services', []);
    angular.module('negwork.controllers', []);

    var config = function config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/home', {
                templateUrl: 'partials/home/home.html',
                controller: 'HomeController',
                controllerAs: 'vm'
            })
            .when('/identity/login', {
                templateUrl: 'partials/identity/login.html',
                controller: 'LoginController',
                controllerAs: 'vm'
            })
            .when('/identity/register', {
                templateUrl: 'partials/identity/register.html',
                controller: 'RegisterController',
                controllerAs: 'vm'
            })
            .otherwise({
                redirectTo: '/home'
            });
    }

    var negNews = angular
        .module('negwork', ['ngRoute', 'ngCookies', 'negwork.controllers', 'negwork.services'])
        .config(['$routeProvider', '$locationProvider', config])
        .constant('apiUrl', 'http://localhost:40471');
    // TODO: Fix url
}());
