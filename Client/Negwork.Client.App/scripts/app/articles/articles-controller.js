(function () {
    'use strict';

    var articlesController = function articlesController(notifier, articles) {
        var vm = this;

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
        .controller('ArticlesController', ['notifier', 'articles', articlesController])
}());