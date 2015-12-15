(function() {
    'use strict';

    angular.module('negwork.controllers', []);

    var negNews = angular
        .module('negwork', ['ngRoute', 'negwork.controllers'])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
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
        }]);
}());
