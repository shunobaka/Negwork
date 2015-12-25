(function () {
    'use strict';

    var addCategoryController = function addCategoryController($location, notifier, categories) {
        var vm = this;

        vm.create = function (category, form) {
            if (form.$valid) {
                categories.add(category)
                    .then(function (response) {
                        notifier.success('Category was successfully created!');
                        $location.path('/categories');
                    }, function (err) {
                        if (err.data.ModelState !== undefined) {
                            for (var prop in err.data.ModelState) {
                                var errors = err.data.ModelState[prop];

                                for (var error in errors) {
                                    notifier.error(errors[error]);
                                }
                            }
                        } else {
                            notifier.error(err.data.Message);
                        }
                    })
            }
        }
    }

    angular
        .module('negwork.controllers')
        .controller('AddCategoryController', ['$location', 'notifier', 'categories', addCategoryController])
}());