(function () {
    'use strict';

    var roundToDecimalFilter = function roundToDecimalFilter() {
        return function (number, place) {
            place = place || 2;

            return number.toFixed(place);
        };
    };

    angular
        .module('negwork.filters')
        .filter('roundToDecimal', roundToDecimalFilter);
}());