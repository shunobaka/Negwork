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
                        notifier.error(err);
                    })
            }
        }
    }

    angular
        .module('negwork.controllers')
        .controller('AddCategoryController', ['$location', 'notifier', 'categories', addCategoryController])
}());