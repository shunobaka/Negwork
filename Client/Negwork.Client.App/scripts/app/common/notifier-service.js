(function () {
    'use strict';

    var notifierService = function notifierService(toastr) {
        toastr.options.preventDuplicates = true;
        toastr.options.closeButton = true;

        return {
            success: function (msg) {
                toastr.success(msg);
            },
            warning: function (msg) {
                toastr.warning(msg);
            },
            error: function (msg) {
                toastr.error(msg);
            }
        };
    };

    angular
        .module('negwork.services')
        .factory('notifier', ['toastr', notifierService]);
}());