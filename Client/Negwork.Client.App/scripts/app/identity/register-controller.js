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
                        var errors = err.data.ModelState[''] || err.data.ModelState['model.Password'];
                        for (var errorIndex in errors) {
                            notifier.error(errors[errorIndex]);
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