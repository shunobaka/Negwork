(function () {
    'use strict';

    var articlesController = function articlesController(auth, notifier, articles) {
        var vm = this;
        vm.currentPage = 1;
        vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';

        vm.pages = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        articles.search()
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
                })
        };

        vm.search = function () {
            vm.request = vm.request || {};
            vm.request.page = vm.currentPage;

            articles.search(vm.request)
                .then(function (response) {
                    vm.articles = response;
                }, function (err) {
                    notifier.error(err);
                });
        };

        vm.goToNextPage = function () {
            if (vm.currentPage < vm.pages.length) {
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
        .controller('ArticlesController', ['auth', 'notifier', 'articles', articlesController])
}());