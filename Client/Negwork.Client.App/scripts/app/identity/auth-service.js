(function () {
    'use strict';

    var authService = function authService($http, $q, $cookies, identity, apiUrl) {
        var TOKEN_KEY = 'authentication';

        var login = function login(user) {
            var deferred = $q.defer();

            var data = "grant_type=password&username=" + (user.username || '') + '&password=' + (user.password || '');

            $http.post(apiUrl + '/api/users/login', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then(function (response) {
                    var tokenValue = response.data.access_token;

                    var theBigDay = new Date();
                    theBigDay.setHours(theBigDay.getHours() + 72);

                    $cookies.put(TOKEN_KEY, tokenValue, { expires: theBigDay });

                    $http.defaults.headers.common.Authorization = 'Bearer ' + tokenValue;

                    getIdentity().then(function () {
                        deferred.resolve(response);
                    });
                }, function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var register = function register(user) {
            var deferred = $q.defer();
            $http.post(apiUrl + '/api/users/register', user)
                .then(function () {
                    deferred.resolve();
                }, function(err) {
                    deferred.reject(err);
                })

            return deferred.promise;
        }

        var getIdentity = function () {
            var deferred = $q.defer();

            $http.get(apiUrl + '/api/users/identity')
                .then(function (identityResponse) {
                    identity.setUser(identityResponse);
                    deferred.resolve(identityResponse);
                });

            return deferred.promise;
        };

        return {
            login: login,
            register: register,
            getIdentity: getIdentity,
            isAuthenticated: function () {
                return !!$cookies.get(TOKEN_KEY);
            },
            logout: function () {
                $cookies.remove(TOKEN_KEY);
                $http.defaults.headers.common.Authorization = null;
                identity.removeUser();
            },
        };
    };

    angular
        .module('negwork.services')
        .factory('auth', ['$http', '$q', '$cookies', 'identity', 'apiUrl', authService]);
}());