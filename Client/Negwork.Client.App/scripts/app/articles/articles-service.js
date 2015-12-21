(function () {
    'use strict';

    var articlesService = function articlesService(data) {
        function add(article) {
            return data.post('/api/articles', article);
        }

        function all() {
            return data.get('/api/articles');
        }

        return {
            add: add,
            all: all
        };
    };

    angular
        .module('negwork.services')
        .factory('articles', ['data', articlesService])
}());