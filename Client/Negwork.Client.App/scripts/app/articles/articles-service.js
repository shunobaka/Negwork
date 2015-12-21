(function () {
    'use strict';

    var articlesService = function articlesService(data) {
        function add(article) {
            return data.post('/api/articles', article);
        }

        function all() {
            return data.get('/api/articles');
        }

        function rate(id, rating) {
            return data.post('/api/ratings/' + id, rating);
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