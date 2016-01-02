(function () {
    'use strict';

    var articleDetailsController = function articleDetailsController($routeParams, $location, auth, notifier, articles) {
        var vm = this;
        var articleId = $routeParams.id;
        vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';

        vm.isAuthenticated = auth.isAuthenticated();

        articles.getById(articleId)
            .then(function (response) {
                vm.article = response;
            }, function () {
                $location.path('/home');
                notifier.error('There was a problem retrieving info for the article.');
            });
    };

    angular
        .module('negwork.controllers')
        .controller('ArticleDetailsController', ['$routeParams', '$location', 'auth', 'notifier', 'articles', articleDetailsController])
}());