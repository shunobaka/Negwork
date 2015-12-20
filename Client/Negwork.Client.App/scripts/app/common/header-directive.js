(function () {
    'use strict';

    var headerDirective = function headerDirective() {
        return {
            restrict: 'A',
            scope: false,
            templateUrl: '../../partials/common/header.html'
        };
    };

    angular
        .module('negwork.directives')
        .directive('header', [headerDirective]);
}());