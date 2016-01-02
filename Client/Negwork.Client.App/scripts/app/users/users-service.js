(function () {
    'use strict';

    var usersService = function usersService(data) {
        function getUserInfo(username) {
            return data.get('/api/users/profile/' + username);
        };

        return {
            getUserInfo: getUserInfo
        };
    }

    angular
        .module('negwork.services')
        .factory('users', ['data', usersService]);
}());