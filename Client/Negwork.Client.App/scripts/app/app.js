(function () {
    'use strict';

    var CONTROLLER_AS_VIEW_MODEL = 'vm';

    angular.module('negwork.filters', []);
    angular.module('negwork.services', []);
    angular.module('negwork.directives', []);
    angular.module('negwork.controllers', []);

    var run = function run($rootScope, $location, $http, $cookies, auth) {
        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
            if (rejection === 'not authorized') {
                $location.path('/unauthorized');
            }
        });

        if (auth.isAuthenticated()) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + $cookies.get('authentication');
            auth.getIdentity();
        }
    };

    var config = function config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        var routeResolvers = {
            authenticationRequired: {
                authenticate: ['$q', 'auth', function ($q, auth) {
                    if (auth.isAuthenticated()) {
                        return true;
                    }

                    return $q.reject('not authorized');
                }]
            }
        }

        $routeProvider
            .when('/home', {
                templateUrl: 'partials/home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/login', {
                templateUrl: 'partials/identity/login.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/register', {
                templateUrl: 'partials/identity/register.html',
                controller: 'RegisterController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/user/settings', {
                templateUrl: 'partials/users/profile-settings.html',
                controller: 'ProfileSettingsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/user/:username', {
                templateUrl: 'partials/users/user-profile.html',
                controller: 'UserProfileController',
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
                controllerAs: CONTROLLER_AS_VIEW_MODEL,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/articles/category/:category', {
                templateUrl: 'partials/articles/articles.html',
                controller: 'ArticlesController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/article/:id', {
                templateUrl: 'partials/articles/article-details.html',
                controller: 'ArticleDetailsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/categories/create', {
                templateUrl: 'partials/categories/create-category.html',
                controller: 'AddCategoryController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/about', {
                templateUrl: 'partials/home/about.html'
            })
            .when('/unauthorized', {
                templateUrl: 'partials/common/unauthorized.html'
            })
            .otherwise({ redirectTo: '/home' });
    }

    var negNews = angular
        .module('negwork', ['ngRoute', 'ngSanitize', 'ngCookies', 'ngAnimate', 'negwork.controllers', 'negwork.services', 'negwork.directives', 'negwork.filters'])
        .config(['$routeProvider', '$locationProvider', config])
        .run(['$rootScope', '$location', '$http', '$cookies', 'auth', run])
        .constant('apiUrl', 'http://localhost:40471')
        .value('toastr', toastr);
    // TODO: Fix url
}());
