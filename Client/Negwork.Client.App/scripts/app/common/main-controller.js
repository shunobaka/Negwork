(function () {
    'use strict';

    function mainController(auth, identity) {
        var vm = this;
        waitForLogin();

        vm.logout = function logout() {
            auth.logout();
            vm.currentUser = undefined;
            waitForLogin();
            $location.path('/');
        };

        function waitForLogin() {
            identity.getUser().then(function (user) {
                vm.currentUser = user;
            });
        }
    };

    angular
        .module('negwork.controllers')
        .controller('MainController', ['auth', 'identity', mainController])
}());