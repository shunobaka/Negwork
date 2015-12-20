(function () {
    'use strict';

    function mainController($location, notifier, auth, identity) {
        var vm = this;
        waitForLogin();

        vm.logout = function logout() {
            auth.logout();
            vm.currentUser = undefined;
            waitForLogin();
            $location.path('/');
            notifier.success('Successfully logged out!');
        };

        function waitForLogin() {
            identity.getUser().then(function (user) {
                vm.currentUser = user;
            });
        }
    };

    angular
        .module('negwork.controllers')
        .controller('MainController', ['$location', 'notifier', 'auth', 'identity', mainController]);
}());