(function () {
    'use strict';

    var articlesController = function articlesController($routeParams, auth, notifier, articles) {
        var vm = this;
        vm.request = {};

        if ($routeParams.category !== undefined) {
            vm.request.category = $routeParams.category;
        }

        vm.currentPage = 1;
        vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';

        articles.search(vm.request)
            .then(function (response) {
                vm.articles = response;
            }, function (err) {
                notifier.error(err);
            });

        vm.isAuthenticated = auth.isAuthenticated();

        vm.rateArticle = function (index, rating) {
            var id = vm.articles[index].Id;
            var data = { ArticleId: id, Rating: rating };

            articles.rate(data)
                .then(function () {
                    notifier.success('Article was successfully rated!');
                }, function (err) {
                    if (!rating) {
                        notifier.error('No rating selected!');
                        return;
                    }

                    var errorMsg = err.data.Message;
                    notifier.error(errorMsg);
                });
        };

        vm.search = function () {
            vm.request.page = vm.currentPage;

            articles.search(vm.request)
                .then(function (response) {
                    vm.articles = response;
                }, function (err) {
                    notifier.error(err);
                });
        };

        vm.goToNextPage = function () {
            if (vm.articles.length == (vm.request.pageSize || 10)) {
                vm.currentPage++;
            }

            vm.search();
        };

        vm.goToPreviousPage = function () {
            if (vm.currentPage > 1) {
                vm.currentPage--;
            }

            vm.search();
        };
    }

    angular
        .module('negwork.controllers')
        .controller('ArticlesController', ['$routeParams', 'auth', 'notifier', 'articles', articlesController])
}());