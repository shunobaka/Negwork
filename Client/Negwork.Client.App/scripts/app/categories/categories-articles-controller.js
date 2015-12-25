(function () {
    'use strict';

    var categoriesArticlesController = function categoriesArticlesController(auth, categories) {
        var vm = this;
        vm.categoryFor = 'articles';
        vm.isAuthenticated = auth.isAuthenticated();

        categories.getForArticles()
            .then(function (articlesCategories) {
                vm.categories = articlesCategories;
            });
    };

    angular
        .module('negwork.controllers')
        .controller('CategoriesArticlesController', ['auth', 'categories', categoriesArticlesController])
}());