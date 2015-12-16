(function () {
    'use strict';

    function RegisterController($location, auth) {
        var vm = this;

        vm.registerUser = function(user, form) {
            if (form.$valid) {
                user.gender = user.gender || "1";

                auth.register(user)
                    .then(function () {
                        $location.path('/identity/login');
                        // TODO: Notify
                    }, function () {
                        // TODO: Notify error
                    });
            } else {
                // TODO: notify problem
            }
        }
    }

    angular.module('negwork.controllers')
		.controller('RegisterController', ['$location', 'auth', RegisterController]);
}());