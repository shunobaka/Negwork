(function () {
    'use strict';

    var categoriesArticlesController = function categoriesArticlesController(categories) {
        var vm = this;
        vm.categoryFor = 'articles';

        categories.getForArticles()
            .then(function (articlesCategories) {
                vm.categories = articlesCategories;
            });
    };

    angular
        .module('negwork.controllers')
        .controller('CategoriesArticlesController', ['categories', categoriesArticlesController])
}());