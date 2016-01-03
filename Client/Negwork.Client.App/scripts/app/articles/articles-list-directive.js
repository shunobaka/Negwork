(function () {
    'use strict';

    var articlesListDirective = function articlesListDirective() {
        return {
            restrict: 'A',
            scope: false,
            templateUrl: '../../partials/articles/articles-list.html'
        };
    };

    angular
        .module('negwork.directives')
        .directive('articlesList', [articlesListDirective]);
}());