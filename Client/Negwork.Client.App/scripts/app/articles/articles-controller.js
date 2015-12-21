(function () {
    'use strict';

    var articlesController = function articlesController(articles) {
        var vm = this;

        vm.articles = articles.all();
    }

    angular
        .module('negwork.controllers')
        .controller('ArticlesController', ['articles', articlesController])
}());