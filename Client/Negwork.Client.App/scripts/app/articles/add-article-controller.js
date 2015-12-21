(function () {
    'use strict';

    var addArticleController = function addArticleController($location, notifier, articles) {
        var vm = this;

        vm.createArticle = function createArticle(article, form) {
            if (form.$valid) {
                article.datePublished = new Date();
                debugger;
                articles
                    .add(article)
                    .then(function (response) {
                        notifier.success('Article successfully created!');
                        $location.path('/articles');
                    }, function (err) {
                        var errors = err.data.ModelState;
                        debugger;
                        for (var errorCategory in errors) {
                            var innerErrors = errors[errorCategory];

                            for (var innerErrorIndex in innerErrors) {
                                notifier.error(innerErrors[innerErrorIndex]);
                            }
                        }
                    });
            }
        }
    };

    angular
        .module('negwork.controllers')
        .controller('AddArticleController', ['$location', 'notifier', 'articles', addArticleController])
}());