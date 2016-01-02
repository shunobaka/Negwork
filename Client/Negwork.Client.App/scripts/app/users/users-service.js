(function () {
    'use strict';

    var usersService = function usersService(data) {
        function getUserInfo(username) {
            return data.get('/api/users/profile/' + username);
        }

        function updateUserInfo(user) {
            return data.put('/api/users/settings', user);
        }

        return {
            getUserInfo: getUserInfo,
            updateUserInfo: updateUserInfo
        };
    }

    angular
        .module('negwork.services')
        .factory('users', ['data', usersService]);
}());