(function () {
    'use strict';

    var dateFormatFilter = function dateFormatFilter() {
        return function (input) {
            var monthNames = [
              "January", "February", "March",
              "April", "May", "June", "July",
              "August", "September", "October",
              "November", "December"
            ];

            var date = new Date(input);
            var day = date.getDate();
            var month = monthNames[date.getMonth()];
            var year = date.getFullYear();
            var hour = date.getHours();
            var minutes = date.getMinutes();

            var resultDate = day + ' ' + month + ' ' + year;

            return resultDate;
        }
    };

    angular
        .module('negwork.filters')
        .filter('dateFormat', [dateFormatFilter]);
}());