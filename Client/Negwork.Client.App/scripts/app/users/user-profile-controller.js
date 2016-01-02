(function () {
    'use strict';

    var userProfileController = function userProfileController($routeParams, $location, notifier, users) {
        var vm = this;
        var username = $routeParams.username;
        vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';

        users.getUserInfo(username)
            .then(function (response) {
                debugger;
                vm.user = response;
            }, function () {
                $location.path('/home');
                notifier.error('There was a problem retrieving info for the user.');
            })
    };

    angular
        .module('negwork.controllers')
        .controller('UserProfileController', ['$routeParams', '$location', 'notifier', 'users', userProfileController]);
}());