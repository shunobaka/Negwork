(function () {
    'use strict';

    var roundToDecimalFilter = function roundToDecimalFilter() {
        return function (number, place) {
            place = place || 2;

            if (number == undefined) {
                return;
            }

            return number.toFixed(place);
        };
    };

    angular
        .module('negwork.filters')
        .filter('roundToDecimal', roundToDecimalFilter);
}());