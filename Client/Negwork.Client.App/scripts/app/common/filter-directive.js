(function () {
    'use strict';

    var filterPanelDirective = function filterPanelDirective() {
        return {
            restrict: 'A',
            scope: false,
            templateUrl: '../../partials/common/filter-panel.html'
        };
    };

    angular
        .module('negwork.directives')
        .directive('filterPanel', [filterPanelDirective]);
}());