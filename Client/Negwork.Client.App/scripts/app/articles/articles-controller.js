(function () {
    'use strict';

    var articlesController = function articlesController(auth, notifier, articles) {
        var vm = this;

        vm.isAuthenticated = auth.isAuthenticated();

        vm.rateArticle = function (index, rating) {
            var id = vm.articles[index];
            articles.rate(id, rating)
                .then(function () {
                    notifier.success('Article was successfully rated!');
                }, function (err) {
                    notifier.error(err);
                })
        };

        articles.all()
            .then(function (response) {
                vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';
                vm.articles = response;
            }, function (err) {
                notifier.error(err);
            });
    }

    angular
        .module('negwork.controllers')
        .controller('ArticlesController', ['auth', 'notifier', 'articles', articlesController])
}());