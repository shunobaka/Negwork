(function () {
    'use strict';

    function RegisterController(auth) {
        var vm = this;

        vm.registerUser = function(user, form) {
            if (form.$valid) {
                debugger;
                auth.register(user)
                    .then(function () {
                        $location.path('/login');
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
		.controller('RegisterController', ['auth', RegisterController]);
}());