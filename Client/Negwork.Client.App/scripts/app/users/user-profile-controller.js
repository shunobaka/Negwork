(function () {
    'use strict';

    var userProfileController = function userProfileController($routeParams, $location, notifier, auth, articles, users) {
        var vm = this;
        var username = $routeParams.username;
        vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';

        vm.isAuthenticated = auth.isAuthenticated();

        articles.getByUser(username)
            .then(function (articles) {
                vm.articles = articles;
            }, function () {
                $location.path('/home');
                notifier.error('Something wrong happened. Try again.');
            });

        users.getUserInfo(username)
            .then(function (response) {
                vm.user = response;
                vm.user.AdditionalInfo = vm.user.AdditionalInfo.replace(/\r?\n/g, '<br />');
            }, function () {
                $location.path('/home');
                notifier.error('There was a problem retrieving info for the user.');
            })

        auth.getIdentity()
            .then(function (user) {
                vm.currentUser = user;
            })
    };

    angular
        .module('negwork.controllers')
        .controller('UserProfileController', ['$routeParams', '$location', 'notifier', 'auth', 'articles', 'users', userProfileController]);
}());