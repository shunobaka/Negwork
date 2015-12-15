(function () {
    'use strict';

    function LoginController(auth) {
        var vm = this;

        vm.loginUser = function loginUser(user, form) {
            if (form.$valid) {
                auth.login(user)
                    .then(function () {
                        // TODO: Notify successful login
                    }, function (error) {
                        // TODO: Notify login error
                    });
            }
        };
    }

    angular.module('negwork.controllers')
        .controller('LoginController', ['auth', LoginController]);
}());