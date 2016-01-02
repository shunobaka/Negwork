(function () {
    'use strict';

    function dataService($http, $q, apiUrl) {

        function get(url, params) {
            var defered = $q.defer();

            $http
                .get(apiUrl + url, {
                    params: params
                })
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function put(url, data) {
            var defered = $q.defer();

            $http
                .put(apiUrl + url, data)
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function post(url, data) {
            var defered = $q.defer();

            $http
                .post(apiUrl + url, data)
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        return {
            get: get,
            post: post,
            put: put
        };
    }


    angular
        .module('negwork.services')
        .factory('data', ['$http', '$q', 'apiUrl', dataService]);
}());