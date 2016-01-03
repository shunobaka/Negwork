(function () {
    'use strict';

    var articlesService = function articlesService(data) {
        var ARTICLES_API_URL = '/api/articles';
        var RATINGS_API_URL = '/api/ratings';

        function add(article) {
            return data.post(ARTICLES_API_URL, article);
        }

        function search(request) {
            return data.get(ARTICLES_API_URL, request);
        }

        function rate(rating) {
            return data.post(RATINGS_API_URL, rating);
        }

        function getById(id) {
            return data.get(ARTICLES_API_URL + '/' + id);
        }

        function getByUser(username) {
            return data.get(ARTICLES_API_URL, { filterBy: 'user', filter: username, orderBy: 'rating', orderType: 'desc' });
        }

        return {
            add: add,
            search: search,
            rate: rate,
            getById: getById,
            getByUser: getByUser
        };
    };

    angular
        .module('negwork.services')
        .factory('articles', ['data', articlesService])
}());