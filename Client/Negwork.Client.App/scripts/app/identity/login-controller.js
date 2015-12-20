(function () {
    'use strict';

    function LoginController($location, notifier, auth) {
        var vm = this;

        vm.loginUser = function loginUser(user, form) {
            if (form.$valid) {
                auth.login(user)
                    .then(function () {
                        $location.path('/');
                        notifier.success('Successfully logged in!');
                    }, function (err) {
                        notifier.error(err);
                    });
            }
        };
    }

    angular.module('negwork.controllers')
        .controller('LoginController', ['$location', 'notifier', 'auth', LoginController]);
}());