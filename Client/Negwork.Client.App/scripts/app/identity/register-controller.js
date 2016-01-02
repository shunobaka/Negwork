(function () {
    'use strict';

    function RegisterController($location, notifier, auth) {
        var vm = this;

        vm.registerUser = function(user, form) {
            if (form.$valid) {
                user.gender = user.gender || "1";

                auth.register(user)
                    .then(function () {
                        $location.path('/identity/login');
                        notifier.success('Registration successful!');
                    }, function (err) {
                        var errorsModelState = err.data.ModelState;

                        for (var modelError in errorsModelState) {
                            for (var errorIndex in errorsModelState[modelError]) {
                                notifier.error(errorsModelState[modelError][errorIndex]);
                            }
                        }
                    });
            } else {
                notifier.error('You shouldn\'t be doing this!');
            }
        }
    }

    angular.module('negwork.controllers')
		.controller('RegisterController', ['$location', 'notifier', 'auth', RegisterController]);
}());