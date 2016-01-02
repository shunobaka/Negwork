(function () {
    'use strict';

    var articleDetailsController = function articleDetailsController($routeParams, $location, auth, notifier, articles, comments) {
        var vm = this;
        var articleId = $routeParams.id;
        vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';

        vm.isAuthenticated = auth.isAuthenticated();

        articles.getById(articleId)
            .then(function (response) {
                debugger;
                vm.article = response;
            }, function () {
                $location.path('/home');
                notifier.error('There was a problem retrieving info for the article.');
            });

        vm.postComment = function (comment) {
            comment.articleId = articleId;

            comments.add(comment)
                .then(function () {
                    notifier.success('Comment was successfully posted!');
                }, function (err) {
                    notifier.error('smth wrng hppnd lel.');
                });
        };

        vm.rateArticle = function (rating) {
            var data = { ArticleId: articleId, Rating: rating };

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
    };

    angular
        .module('negwork.controllers')
        .controller('ArticleDetailsController', ['$routeParams', '$location', 'auth', 'notifier', 'articles', 'comments', articleDetailsController])
}());