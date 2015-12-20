(function () {
    'use strict';

    var datepickerDirective = function datepickerDirective() {
        return {
            restrict: 'A',
            scope: false,
            link: function (scope, element) {
                element.datepicker({
                    dateFormat: 'mm/dd/yy'
                });
            }
        }
    };

    angular
        .module('negwork.directives')
        .directive('datepicker', [datepickerDirective]);
}());