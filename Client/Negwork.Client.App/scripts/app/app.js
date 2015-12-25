(function() {
    'use strict';

    var CONTROLLER_AS_VIEW_MODEL = 'vm';

    angular.module('negwork.filters', []);
    angular.module('negwork.services', []);
    angular.module('negwork.directives', []);
    angular.module('negwork.controllers', []);

    var run = function run($http, $cookies, auth) {
        if (auth.isAuthenticated()) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + $cookies.get('authentication');
            auth.getIdentity();
        }
    };

    var config = function config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/home', {
                templateUrl: 'partials/home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/identity/login', {
                templateUrl: 'partials/identity/login.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/identity/register', {
                templateUrl: 'partials/identity/register.html',
                controller: 'RegisterController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/articles/all', {
                templateUrl: 'partials/articles/articles.html',
                controller: 'ArticlesController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/articles/categories', {
                templateUrl: 'partials/categories/categories.html',
                controller: 'CategoriesArticlesController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/articles/create', {
                templateUrl: 'partials/articles/create-article.html',
                controller: 'AddArticleController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/articles/category/:category', {
                templateUrl: 'partials/articles/articles.html',
                controller: 'ArticlesController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/categories/create', {
                templateUrl: 'partials/categories/create-category.html',
                controller: 'AddCategoryController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .otherwise({
                redirectTo: '/home'
            });
    }

    var negNews = angular
        .module('negwork', ['ngRoute', 'ngCookies', 'ngAnimate', 'negwork.controllers', 'negwork.services', 'negwork.directives', 'negwork.filters'])
        .config(['$routeProvider', '$locationProvider', config])
        .run(['$http', '$cookies', 'auth', run])
        .constant('apiUrl', 'http://localhost:40471')
        .value('toastr', toastr);
    // TODO: Fix url
}());
