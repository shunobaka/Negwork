(function () {
    'use strict';

    var profileSettingsController = function profileSettingsController(auth, notifier, users) {
        var vm = this;
        vm.DefaultProfile = 'https://diasp.eu/assets/user/default.png';

        auth.getIdentity()
            .then(function (user) {
                vm.currentUser = user;
                vm.currentProfileImage = vm.currentUser.ProfileImage;
            }, function () {
                notifier.error('There was a problem editing your profile. Please try again.');
            });

        vm.saveChanges = function () {
            vm.currentUser.ProfileImage = vm.newProfileImage;

            users.updateUserInfo(vm.currentUser)
                .then(function () {
                    vm.currentProfileImage = vm.currentUser.ProfileImage;
                    notifier.success('Profile was updated successfully!');
                }, function (err) {
                    var error = err.data;
                    if (error.ModelState !== undefined) {
                        var modelState = error.ModelState;
                        for (var prop in modelState) {
                            for (var errIndex in modelState[prop]) {
                                notifier.error(modelState[prop][errIndex]);
                            }
                        }
                    }
                });
        };
    }

    angular
        .module('negwork.controllers')
        .controller('ProfileSettingsController', ['auth', 'notifier', 'users', profileSettingsController]);
}());