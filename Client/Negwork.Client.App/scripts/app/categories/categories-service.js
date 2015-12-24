(function () {
    'use strict';

    var categoriesService = function categoriesService(data) {
        var CATEGORIES_API_URL = '/api/categories';

        function getAll() {
            return data.get(CATEGORIES_API_URL);
        }

        function getById(id) {
            return data.get(CATEGORIES_API_URL + '/' + id);
        }

        function getForArticles() {
            return data.get(CATEGORIES_API_URL + '/articles');
        }

        function getForImages() {
            return data.get(CATEGORIES_API_URL + '/images');
        }

        function add(category) {
            return data.post(CATEGORIES_API_URL, category);
        }

        return {
            getAll: getAll,
            getById: getById,
            getForArticles: getForArticles,
            getForImages: getForImages,
            add: add
        };
    }

    angular
        .module('negwork.services')
        .factory('categories', ['data', categoriesService]);
}());